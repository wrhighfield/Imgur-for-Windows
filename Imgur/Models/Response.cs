using System;
using System.Collections.Generic;
using System.Text;

namespace Imgur.Models
{
    public class Response{
        public object Data { get; set; }
        public bool Success { get; set; }

        public Response(bool _success, object _data = null)
        {
            Data = _data;
            Success = _success;
        }
    }
}
