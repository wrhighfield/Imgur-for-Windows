using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.Constants
{
    public static class LocalSettingsConstants { 


        public const string LiveTiles = "LiveTiles";

        public const string RemindNotifications = "RemindNotifications";

        public const string DataNotifications = "DataNotifications";

        public const string HDonWifi = "HDonWifi";

        public static IReadOnlyDictionary<string, object> Defaults { get; } = new Dictionary<string, object>()
            {
                { LiveTiles, true },
                { RemindNotifications, true },
                { DataNotifications, true },
                { HDonWifi, false }
            };


}
}
