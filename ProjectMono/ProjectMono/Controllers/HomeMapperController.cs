using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Service.Models;
using ProjectMono.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Project.Service;
using System.Collections.Generic;
using X.PagedList;
using System.Diagnostics;

namespace ProjectMono.Controllers
{
    public class HomeMapperController : Controller
    {
        /// <summary>
        /// Constructor injection
        /// </summary>
        private readonly IMonoRepositry _context;
        private readonly IMapper _mapper;
        public HomeMapperController(IMonoRepositry context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public  IActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
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
            ViewData["CurrentFilter"] = searchString;
            var pageNumber = page ?? 1;

            //no matter what, this code is fill a container
            var model = _context.GetAllVehicleMakes();
            var mapper_model = _mapper.Map<List<VehicleMakeDTO>>(model);
            var mapperForView = _mapper.Map<List<VehicleMakeDTO>>(model);

            //in search case 
            if (!string.IsNullOrEmpty(searchString))
            {
                var  mapperForViewSearch = mapper_model.Where(x => x.Name.Contains(searchString) || x.Abrv.Contains(searchString));
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
            return View(mapperForView.ToList().ToPagedList(pageNumber, 5));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            int ID = id.GetValueOrDefault();
            if (id == null)
            {
                return NotFound();
            }
            var vehicleMake = await _context.GetVehicle(ID);
            if (vehicleMake == null)
            {
                return NotFound();
            }
            return View(vehicleMake);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            int ID = id.GetValueOrDefault();
            if (id == null)
            {
                return NotFound();
            }
            var vehicleMake = await _context.GetVehicle(ID);
            if(vehicleMake == null)
            {
                return NotFound();
            }
            return View(vehicleMake);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Abrv")] VehicleMake vehicle)
        {
        
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _context.UpdateVehicleMake(vehicle);
                }
                catch (DbUpdateConcurrencyException)
                {
                        return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }

            return View(vehicle);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Abrv")] VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                await _context.AddNew(vehicleMake);
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleMake);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _context.Delete(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}