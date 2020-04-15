using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcore_configurations.Models.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace dotnetcore_configurations.Controllers
{
    public class Dashboard2Controller : Controller
    {
        private readonly DashboardHeaderConfiguration dashboardHeaderConfig;

        //public Dashboard2Controller(IOptions<DashboardHeaderConfiguration> options)
        //{
        //    dashboardHeaderConfig = options.Value;
        //}

        public Dashboard2Controller(IOptionsSnapshot<DashboardHeaderConfiguration> optionsSnapshot)
        {
            dashboardHeaderConfig = optionsSnapshot.Value;
        }

        public IActionResult Index()
        {
            return Content(JsonConvert.SerializeObject(dashboardHeaderConfig));
        }
    }
}