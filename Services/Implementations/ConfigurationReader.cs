using dotnetcore_configurations.Models.Configuration;
using dotnetcore_configurations.Services.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;

namespace dotnetcore_configurations.Services.Implementations
{
    public class ConfigurationReader : IConfigurationReader
    {
        private DashboardHeaderConfiguration dashboardHeaderConfig;

        public ConfigurationReader(IOptionsMonitor<DashboardHeaderConfiguration> optionsMonitor)
        {
            this.dashboardHeaderConfig = optionsMonitor.CurrentValue;
            optionsMonitor.OnChange(config =>
            {
                this.dashboardHeaderConfig = config;
            });
        }

        public string ReadDashboardHeaderSettings()
        {
            return JsonConvert.SerializeObject(this.dashboardHeaderConfig);
        }
    }
}
