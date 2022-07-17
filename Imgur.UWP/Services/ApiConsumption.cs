using Imgur.API;
using Imgur.API.Resources;
using Imgur.Models;
using Imgur.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.UWP.Services
{
    public class ApiConsumption : IAPIConsumption{

        private APIService _apiService;

        public ApiConsumption(){
            _apiService = new APIService("b6c4abc4061d423");
        }

        public List<Category> GetExplorerGalleries()
        {
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



        public async Task<Response> GetExplorerMedia(int gallery, int sort){


            List<Media> Images = new List<Media>();

            if (true){

               Response<List<Datum>> retrievedMedia = await _apiService.get_ExplorerMedia(gallery, sort);
             
               if(retrievedMedia.success){
                    foreach (Datum element in retrievedMedia.data){
                        Media MediaObject = new Media();
                        MediaObject.id = element.id;
                        MediaObject.title = element.title;
                        MediaObject.description = element.description;
                        MediaObject.datetime = element.datetime;
                        MediaObject.views = element.views;
                        MediaObject.ups = element.ups;
                        MediaObject.coverlink = element.cover;
                        MediaObject.comment_count = element.comment_count;
                        MediaObject.images_count = element.images_count;
                        MediaObject.is_album = element.is_album;

                        if (element.is_album){
                            MediaObject.coverlink = element.cover;
                            MediaObject.covertype = !string.IsNullOrEmpty(element.images[0].type) ? element.images[0].type : "";
                        }else{
                            MediaObject.coverlink = element.id;
                            MediaObject.covertype = !string.IsNullOrEmpty(element.type) ? element.type : "";
                        }


                        if (MediaObject.covertype == "image/gif"){
                            MediaObject.coveruri = "https://i.imgur.com/" + MediaObject.coverlink + ".gif";
                        }else{
                            MediaObject.coveruri = "https://i.imgur.com/" + MediaObject.coverlink + "_d.gif?maxwidth=500&fidelity=low";
                        }

                        Images.Add(MediaObject);


                    }

                 

                    return new Response(true, Images);
                }else{
                    return new Response(false);
                }
            }
        }
    }
}
