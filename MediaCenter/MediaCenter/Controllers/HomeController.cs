using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediaCenter.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace MediaCenter.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _configuration;
        private readonly Locations _locations;

        public HomeController(IConfiguration configuration, IOptions<Locations> options)
        {
            _configuration = configuration;
            _locations = options.Value;
        }
       
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Settings()
        {

            //  var array =_configuration.GetSection("Locations:Location").GetChildren()
            //    .Select(configsection => configsection.Value);


            var locations = new Locations();
            _configuration.GetSection("Locations").Bind(locations);

            var items = locations.location.AsEnumerable();
            var items2 = _locations;



            return View();
        }
        
    }
}
