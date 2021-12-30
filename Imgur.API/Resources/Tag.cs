using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API.Resources
{
    public class Tag{
        public string name { get; set; }
        public string display_name { get; set; }
        public int followers { get; set; }
        public int total_items { get; set; }
        public bool following { get; set; }
        public bool is_whitelisted { get; set; }
        public string background_hash { get; set; }
        public string thumbnail_hash { get; set; }
        public string accent { get; set; }
        public bool background_is_animated { get; set; }
        public bool thumbnail_is_animated { get; set; }
        public bool is_promoted { get; set; }
        public string description { get; set; }
        public object logo_hash { get; set; }
        public object logo_destination_url { get; set; }
        public DescriptionAnnotations description_annotations { get; set; }
    }
}
