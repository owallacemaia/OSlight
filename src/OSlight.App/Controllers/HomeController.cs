using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OSlight.App.Models;
using OSlight.App.ViewModels;
using OSlight.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OSlight.App.Controllers
{
    public class HomeController : Controller
    {
        protected readonly IFecharOSRepository _fecharOSRepository;
        protected readonly IAbrirOSRepository _abrirOSRepository;
        protected readonly IMapper _mapper;

        public HomeController(
            IFecharOSRepository fecharOSRepository,
            IAbrirOSRepository abrirOSRepository)
        {
            _fecharOSRepository = fecharOSRepository;
            _abrirOSRepository = abrirOSRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
