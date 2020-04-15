using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ProjectMono.Controllers
{
    public class ErrorController : Controller
    {

        [Route("Error")]
        public IActionResult Error500()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionFeature != null)
            {
                ViewBag.ErrorMessage = exceptionFeature.Error.Message;
                ViewBag.RouteOfException = exceptionFeature.Path;
            }

            return View();
        }

        [Route("Error/{statusCode}")]
        public IActionResult HandleErrorCode(int statusCode)
        {
            var statusCodeData = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Pardon, stranice nema";
                    ViewBag.RouteOfException = statusCodeData.OriginalPath;
   
                    
                    break;
                case 500:
                    ViewBag.ErrorMessage = "Greška!";
                    ViewBag.RouteOfException = statusCodeData.OriginalPath;
                    break;

                default:
                    ViewBag.ErrorMessage = "Greška!";
                    break;
            }

            return View();
        }
    }
}