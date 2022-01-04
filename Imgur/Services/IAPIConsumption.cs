using Imgur.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imgur.Services
{
    public interface IAPIConsumption{

        List<Category> GetExplorerGalleries();


        List<Category> GetExplorerSort();


    }
}
