using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Service;
using Project.Service.Models;
//using ProjectMono.Models;

namespace ProjectMono.Controllers
{
    public class VehicleModelsController : Controller
    {
        /// <summary>
        ///  Construcotr injection
        /// </summary>
        private readonly AppDbContext _context;
        public VehicleModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: VehicleModels
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            #region
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var _vehicleModel = from v in _context.vehicleModels
                                select v;

            if (!String.IsNullOrEmpty(searchString))
            {
                _vehicleModel = _vehicleModel.Where(x => x.Name.Contains(searchString) || x.Abrv.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    _vehicleModel = _vehicleModel.OrderBy(x => x.Name);
                    break;
            }
            ViewBag.VehicleMakes = _context.vehicleMakes.ToList();
            int pageSize = 5;
            return View(await PaginatedList<VehicleModel>.CreateAsync(_vehicleModel.AsNoTracking(), pageNumber ?? 1, pageSize));
            #endregion
        }

        // GET: VehicleModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.vehicleModels.FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleModel == null)
            {
                return NotFound();
            }
            ViewBag.VehicleMakes = _context.vehicleMakes.ToList();

            return View(vehicleModel);
        }

        // GET: VehicleModels/Create
        public IActionResult Create()
        {
            var CarMakeModel = (from model in  _context.vehicleMakes select model).ToList();
            CarMakeModel.Insert(0, new VehicleMake { Id = 0, Name = "Select" });
            ViewBag.List = CarMakeModel;
            return View();
        }

        // POST: VehicleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,Abrv")] VehicleModel vehicleModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(vehicleModel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(vehicleModel);
        //}
        [HttpGet()]
        public async Task<ActionResult> CreateModel(string name, string abrv, int MakeId)
        {
            VehicleModel vehicleModel = new VehicleModel();
            vehicleModel.Name = name;
            vehicleModel.Abrv = abrv;
            vehicleModel.MakeId = MakeId;

                _context.Add(vehicleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: VehicleModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.vehicleModels.FindAsync(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            var CarMakeModel = (from model in _context.vehicleMakes select model).ToList();
            CarMakeModel.Insert(0, new VehicleMake { Id = 0, Name = "Select" });
            ViewBag.List = CarMakeModel;

            return View(vehicleModel);
        }

        // POST: VehicleModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Abrv")] VehicleModel vehicleModel)
        public async Task<IActionResult> Edit(int id, string name, string abrv, int makeId, VehicleModel vehicleModel)
        {
            //VehicleModel vehicleModel = new VehicleModel();
            if (id != vehicleModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleModelExists(vehicleModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleModel);
        }

        // GET: VehicleModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.vehicleModels
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var vehicleModel = await _context.vehicleModels.FindAsync(id);
            _context.vehicleModels.Remove(vehicleModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleModelExists(int id)
        {
            return _context.vehicleModels.Any(e => e.Id == id);
        }


        #region partial view
        public IActionResult DropDownVehicleMake()
        {
            var model = from u in _context.vehicleMakes
                        orderby u.Name
                        select u;
            return View(model);
        }
    }
    #endregion
}

