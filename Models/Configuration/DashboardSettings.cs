using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcore_configurations.Models.Configuration
{
    public class DashboardSettings
    {
        public string Title { get; set; }

        public DashboardHeaderSettings Header { get; set; }
    }
}
