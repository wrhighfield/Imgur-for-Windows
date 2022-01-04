using Imgur.Models;
using Imgur.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.UWP.Services
{
    public class ApiConsumption : IAPIConsumption{

        public List<Category> GetExplorerGalleries(){
            List<Category> ExplorerGalleries = new List<Category>();
            ExplorerGalleries.Add(new Category("", "Most Viral", "\uEC24"));
            ExplorerGalleries.Add(new Category("", "User Submitted", "\uE902"));
            ExplorerGalleries.Add(new Category("", "Highest Score", "\uEAFC"));
            return ExplorerGalleries;
        }


        public List<Category> GetExplorerSort(){
            List<Category> ExplorerSort = new List<Category>(); 
            ExplorerSort.Add(new Category("", "Popular", ""));
            ExplorerSort.Add(new Category("", "Newest", ""));
            ExplorerSort.Add(new Category("", "Best", ""));
            ExplorerSort.Add(new Category("", "Random", ""));
            return ExplorerSort;
        }

        public object GetExplorerImages(int gallery, int sort){
            ObservableCollection<Category> Images = new ObservableCollection<Category>();

            //If Network is Up
            if (true){
                return Images;
            }else{           
                return false;
            }
        }
    }
}
