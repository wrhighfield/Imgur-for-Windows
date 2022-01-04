using Imgur.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace Imgur.UWP.Services
{
    public class AppSettings : IAppSettings{

        public AppSettings(){
            var resourceLoader = ResourceLoader.GetForCurrentView("appsettings");
            ApiKey = resourceLoader.GetString(nameof(ApiKey));
        }

        public string ApiKey { get; }

    }
}
