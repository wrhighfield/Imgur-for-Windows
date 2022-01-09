using Imgur.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.Services
{
    public interface IAPIConsumption{

        List<Category> GetExplorerGalleries();
    
        List<Category> GetExplorerSort();

        Task<Response> GetExplorerMedia(int gallery, int sort);




    }
}
