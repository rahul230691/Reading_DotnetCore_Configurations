using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcore_configurations.Models.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace dotnetcore_configurations.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IConfiguration configuration;

        //requires using Microsoft.Extensions.Configuration
        public DashboardController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IActionResult Index2()
        {
            var dashboardSettings = new DashboardSettings();
            configuration.Bind("DashboardSettings", dashboardSettings);

            //requires using Newtonsoft.Json
            return Content(JsonConvert.SerializeObject(dashboardSettings));
        }

        public IActionResult Index()
        {
            List<object> listSettings = new List<object>();

            //var dashboardTitle = configuration.GetValue<string>("DashboardSettings:Title");

            var headerSection = configuration.GetSection("DashboardSettings:Header");
            var isSearchBoxEnabled = headerSection.GetValue<bool>("IsSearchBoxEnabled");
            var headerBannerTitle = headerSection.GetValue<string>("BannerTitle");
            var isBannerSliderEnabled = headerSection.GetValue<bool>("IsBannerSliderEnabled");

            listSettings.AddRange(new object[] { isSearchBoxEnabled, headerBannerTitle, isBannerSliderEnabled });

            //requires using Newtonsoft.Json
            return Content(JsonConvert.SerializeObject(listSettings));
        }

        
    }
}
