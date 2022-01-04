using System;
using System.Collections.Generic;
using System.Text;

namespace Imgur.Models
{
    public class Category
    {


        public Category(string id,string name, string glyph){
            Id = id;
            Name = name;
            Glyph = glyph;
        }

        //Id for Translation
        public string Id { get; set; } = "";


        public string Glyph { get; set; } = "";

        public string Name { get; set; } = "";



    }
}
