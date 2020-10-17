using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RotativaAspNetCoreDemo.Models;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;

namespace RotativaAspNetCoreDemo.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index(string export)
        {
            CountryPopulationViewModel viewModel = CountryPopulationService.GetResults();
            if (string.IsNullOrEmpty(export))
            {
                return View(viewModel);
            }
            else
            {
                viewModel.ForExport = true;
                return ViewAsPdf(viewModel);
            }
        }

        private ViewAsPdf ViewAsPdf(object viewModel)
        {
            string authority = $"{(Request.IsHttps ? "https" : "http")}://{Request.Host}";
            string headerHtml = $"{authority}/ExportHeader.html";
            string footerHtml = $"{authority}/ExportFooter.html";
            return new ViewAsPdf
            {
                Model = viewModel,
                PageMargins = new Margins { Left = 10, Right = 10, Top = 20, Bottom = 20 },
                PageSize = Size.A4,
                PageOrientation = Orientation.Portrait,
                CustomSwitches = $"--header-html \"{headerHtml}\" --footer-html \"{footerHtml}\" --header-spacing 5 --footer-spacing 5"
            };
        }
    }
}

