using dotnetcore_configurations.Models.Configuration;
using dotnetcore_configurations.Services.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcore_configurations.Services.Implementations
{
    public class ThemeConfigurationReader : IThemeConfigurationReader
    {
        //NormalThemeDashboardSettings normalThemeSettings;
        //DarkThemeDashboardSettings darkThemeSettings;

        //public ThemeConfigurationReader(
        //        IOptions<NormalThemeDashboardSettings> normalThemeOptions, 
        //        IOptions<DarkThemeDashboardSettings> darkThemeOptions)
        //{
        //    normalThemeSettings = normalThemeOptions.Value;
        //    darkThemeSettings = darkThemeOptions.Value;
        //}

        private readonly DashboardThemeSettings _noralThemeSettings;
        private readonly DashboardThemeSettings _darkThemeSettings;

        public ThemeConfigurationReader(IOptionsMonitor<DashboardThemeSettings> optionsMonitor)
        {
            _noralThemeSettings = optionsMonitor.Get("Normal");
            _darkThemeSettings = optionsMonitor.Get("Dark");
        }

        public string ReadThemeSettings()
        {
            //return JsonConvert.SerializeObject(new
            //{
            //    this.normalThemeSettings,
            //    this.darkThemeSettings
            //});
            return JsonConvert.SerializeObject(new
            {
                this._noralThemeSettings,
                this._darkThemeSettings
            });
        }
    }
}
