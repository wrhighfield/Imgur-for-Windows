using Imgur.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.Models
{
    public class Media : Observable
    {

        public Media(){
            coverLoaded = false;
        }

        public bool is_album { get; set; }

        public int images_count { get; set; }
        public string covertype { get; set; }

        public string coverlink { get; set; }

        public string coveruri { get; set; }

        public string coverImage { get; set; }

        public bool coverLoaded { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int datetime { get; set; }

        public int views { get; set; }

        public int ups { get; set; }

        public int comment_count { get; set; }

        public async Task RetrieveImageAsync(){
            //Get cover
            
            if(covertype != "image/gif" && covertype != "video/mp4"){
                /*
                HttpClient Client = new HttpClient();


                HttpResponseMessage HttpRequest = await Client.GetAsync(coveruri);
                if (HttpRequest.StatusCode == HttpStatusCode.OK){
                    this.coverLoaded = true;
                    //this.coverImage = Convert.ToBase64String(await HttpRequest.Content.ReadAsByteArrayAsync());         
                    Debug.WriteLine($"{coverlink} - {covertype} - {coveruri}");               
                }
                Client.Dispose();
                */
            }
            else{
                this.coverImage = this.coveruri;
                this.coverLoaded = true;
            }

            /*  REMOVE LATER */
            this.coverImage = this.coveruri;
            this.coverLoaded = true;

            OnPropertyChanged("coverImage");
            OnPropertyChanged("coverLoaded");
            await Task.Delay(500);
        }


    }
}
