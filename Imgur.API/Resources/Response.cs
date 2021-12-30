using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API.Resources
{
    public class Response<T>{
        public T data { get; set; }
        public bool success { get; set; }
        public int status { get; set; }
    }
}
