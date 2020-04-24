using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Service;
using Project.Service.Models;
using ProjectMono.Models;
using X.PagedList;
//using ProjectMono.Models;

namespace ProjectMono.Controllers
{
    public class VehicleModelsController : Controller
    {
        private readonly Project.Service.Models.IVehicleModelRepository context;
        //private readonly IVehicleModelRepository _contextM;
        private readonly IMapper _mapper;
        public VehicleModelsController(IVehicleModelRepository context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;

        }

        // GET: VehicleModels
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
         
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["AbrvSortParm"] = String.IsNullOrEmpty(sortOrder) ? "abrv_desc" : "";
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            var pageNumber = page ?? 1;
            ViewData["CurrentFilter"] = searchString;

            var vehicleModel = context.GetAllVehicleModels();
            var mapperModel = _mapper.Map<List<VehicleModelDTO>>(vehicleModel);
            var mapperForView = _mapper.Map<List<VehicleModelDTO>>(vehicleModel);


            if (!String.IsNullOrEmpty(searchString))
            {
                var mapperForViewSearch = mapperModel.Where(x => x.Name.Contains(searchString) || x.Abrv.Contains(searchString));
                return View(mapperForViewSearch.ToList().ToPagedList(pageNumber, 5));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    mapperForView = mapperForView.OrderBy(x => x.Name).ToList();
                    break;
                case "abrv_desc":
                    mapperForView = mapperForView.OrderBy(x => x.Abrv).ToList();
                    break;
            }
            ViewBag.VehicleMakes = context.GetVehicleMakes();
            return View(await mapperForView.ToList().ToPagedListAsync(pageNumber, 5));
          
        }

        // GET: VehicleModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            int ID = id.GetValueOrDefault();
            var vehicleModel = await context.GetModel(ID);
            if (vehicleModel == null)
            {
                return NotFound();
            }
            ViewBag.VehicleMakes = context.GetVehicleMakes();
            return View(vehicleModel);
        }

        // GET: VehicleModels/Create
        public IActionResult Create()
        {
            var CarMakeModel = context.GetVehicleMakes().ToList();
            CarMakeModel.Insert(0, new VehicleMake { Id = 0, Name = "Select" });
            ViewBag.List = CarMakeModel;
            return View();
        }

        //other way of create not the same as others just to show!
        [HttpGet()]
        public async Task<ActionResult> CreateModel(string name, string abrv, int MakeId)
        {
            VehicleModel vehicleModel = new VehicleModel();
            vehicleModel.Name = name;
            vehicleModel.Abrv = abrv;
            vehicleModel.MakeId = MakeId;
           await context.AddNew(vehicleModel);
           return RedirectToAction(nameof(Index));
        }

        // GET: VehicleModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
         
            if (id == null)
            {
                return NotFound();
            }
            int ID = id.GetValueOrDefault();
            var vehicleModel = await context.GetModel(ID);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            //needs for listing car makes
            var CarMakeModel = context.GetVehicleMakes().ToList();
            CarMakeModel.Insert(0, new VehicleMake { Id = 0, Name = "Select" });
            ViewBag.List = CarMakeModel;
            return View(vehicleModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string name, string abrv, int makeId, VehicleModel vehicleModel)
        {
            if (id != vehicleModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await context.UpdateVehicleModel(vehicleModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleModelExists(vehicleModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        return Error();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleModel);
        }

        // GET: VehicleModels/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var vehicleModel = await context.GetModel(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }
            return View(vehicleModel);
        }

        // POST: VehicleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var vehicleModel = await context.GetModel(id);
            await context.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleModelExists(int id)
        {
            if(context.GetModel(id) != null)
            {
                return true;
            }
            return false;
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
 
}

