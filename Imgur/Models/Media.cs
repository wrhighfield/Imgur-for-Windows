using Imgur.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imgur.Models
{
    public class Media : Observable{

        public bool is_album { get; set; }

        public int images_count { get; set; }
        public string covertype { get; set; }

        public string coverlink { get; set; }

        public string coveruri { get; set; }

        public bool coverLoaded { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int datetime { get; set; }

        public int views { get; set; }

        public int ups { get; set; }

        public int comment_count { get; set; }

    }
}
