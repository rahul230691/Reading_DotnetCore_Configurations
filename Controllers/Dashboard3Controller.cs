using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcore_configurations.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dotnetcore_configurations.Controllers
{
    public class Dashboard3Controller : Controller
    {
        private readonly IConfigurationReader configurationReader;

        public Dashboard3Controller(IConfigurationReader configurationReader)
        {
            this.configurationReader = configurationReader;
        }

        public IActionResult Index()
        {
            return Content(this.configurationReader.ReadDashboardHeaderSettings());
        }
    }
}