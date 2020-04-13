using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcore_configurations.Models.Configuration
{
    public class DashboardHeaderSettings
    {
        public bool IsSearchBoxEnabled { get; set; }
        public string BannerTitle { get; set; }
        public bool IsBannerSliderEnabled { get; set; }
    }
}
