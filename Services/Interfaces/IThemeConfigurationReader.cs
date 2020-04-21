using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcore_configurations.Services.Interfaces
{
    public interface IThemeConfigurationReader
    {
        string ReadThemeSettings();
    }
}
