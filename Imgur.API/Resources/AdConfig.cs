using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API.Resources
{
    public class AdConfig{

        public List<string> safeFlags { get; set; }
        public List<object> highRiskFlags { get; set; }
        public List<string> unsafeFlags { get; set; }
        public List<object> wallUnsafeFlags { get; set; }
        public bool showsAds { get; set; }

    }
}
