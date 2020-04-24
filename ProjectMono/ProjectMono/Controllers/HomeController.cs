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
using System.Diagnostics;
using System.Data.SqlClient;

namespace ProjectMono.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Constructor injection
        /// </summary>
        private readonly Project.Service.Models.DbContext context;
        // private readonly IMonoRepositry _context;
        private readonly IMapper _mapper;

        public HomeController(Project.Service.Models.DbContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            #region
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["AbrvSortParm"] = String.IsNullOrEmpty(sortOrder) ? "abrv_desc" : "";
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

            //no matter what, this code is fill a container
            var vehicleMake = from v in context.vehicleMakes
                               select v;

            if (!string.IsNullOrEmpty(searchString))
            {
                vehicleMake = vehicleMake.Where(x => x.Name.Contains(searchString) || x.Abrv.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    vehicleMake = vehicleMake.OrderBy(x => x.Name);
                    break;
                case "abrv_desc":
                    vehicleMake = vehicleMake.OrderBy(x => x.Abrv);
                    break;
            }

            int pageSize = 5;
            var mappetList = _mapper.Map<List<VehicleMakeDTO>>(vehicleMake);

            return View(await Models.PaginatedList<VehicleMake>.CreateAsync(vehicleMake.AsNoTracking(), pageNumber ?? 1, pageSize));
            #endregion


        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleMake = await context.vehicleMakes.FindAsync(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            return View(vehicleMake);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await context.vehicleMakes.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Abrv")] VehicleMake vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(vehicle);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleMakeExists(vehicle.Id))
                    {
                        return NotFound();
                    }

                }
                return RedirectToAction(nameof(Index));
            }

            return View(vehicle);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return  View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Abrv")] VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                context.Add(vehicleMake);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(vehicleMake);
        }

        public IActionResult Delete(int id)
        {
            VehicleMake vehicle = context.vehicleMakes.Find(id);
            if (vehicle != null)
            {
                var commandText = "delete from VehicleModel where MakeId = @id";
                var vehicle_model = new SqlParameter("@id", id);
                context.Database.ExecuteSqlCommand(commandText, vehicle_model);
                context.vehicleMakes.Remove(vehicle);
                context.SaveChanges();
            }
            //return RedirectToAction("Index/");
            return View();
        }

        #region ne upotrebljava se
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        #endregion


        /// <summary>
        /// check if exist, koristim za update
        /// </summary>
        /// <returns></returns>
        /// 
        private bool VehicleMakeExists(int id)
        {
            return context.vehicleMakes.Any(e => e.Id == id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
