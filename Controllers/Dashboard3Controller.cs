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
        private readonly IConfigurationReader _configurationReader;
        private readonly IThemeConfigurationReader _themeConfigurationReader;

        public Dashboard3Controller(
            IConfigurationReader configurationReader,
            IThemeConfigurationReader themeConfigurationReader)
        {
            this._configurationReader = configurationReader;
            this._themeConfigurationReader = themeConfigurationReader;
        }

        public IActionResult Index()
        {
            return Content(this._configurationReader.ReadDashboardHeaderSettings());
        }

        public IActionResult Index2()
        {
            return Content(this._themeConfigurationReader.ReadThemeSettings());
        }
    }
}