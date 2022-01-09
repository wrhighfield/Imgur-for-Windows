using Imgur.API.Resources;
using Imgur.API.Resources.Status;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API
{
    public class APIService
    {





        private HttpClient Client;
        private string ClientID;
        private string UrlBase;

        public APIService(string clientid)
        {

            ClientID = clientid;

            //Set Http Headers
            InitalizeHTTPClient();

        }


        private void InitalizeHTTPClient()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("Authorization", "Client-ID " + ClientID);
            Client.Timeout = TimeSpan.FromSeconds(60);

        }

        public async Task<Response<Component>> get_ApiStatus(){

            var ApiResponse = new Response<Component>();

            try{
                HttpResponseMessage HttpRequest = await Client.GetAsync("https://status.imgur.com/api/v2/summary.json");
                if (HttpRequest.StatusCode == HttpStatusCode.OK){
                    string ResponseBody = await HttpRequest.Content.ReadAsStringAsync();
                    Root Response = JsonConvert.DeserializeObject<Root>(ResponseBody);

                    //Workaroung to get only the Public API 
                    ApiResponse.success = true;
                    ApiResponse.status = (int)HttpRequest.StatusCode;
                    ApiResponse.data = Response.components.Find(x => x.id == "4c0md1fmxz62");
                    return (ApiResponse);
                }else{
                    ApiResponse.success = true;
                    ApiResponse.status = (int)HttpRequest.StatusCode;
                    return (ApiResponse);
                }

            }catch (Exception e){
                ApiResponse.success = false;
                ApiResponse.status = -1;
                return (ApiResponse);
            }
        }

        public async Task<Response<List<Datum>>> get_ExplorerMedia(int sectionId,int sortId,int page=0 ){
            Response<List<Datum>> ApiResponse = new Response<List<Datum>>();
            try{
                HttpResponseMessage HttpRequest = await Client.GetAsync("https://api.imgur.com/3/gallery/hot/viral/0");
                if(HttpRequest.StatusCode == HttpStatusCode.OK){
                    string ResponseBody = await HttpRequest.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Response<List<Datum>>>(ResponseBody);
                }else{
                    ApiResponse.success = true;
                    ApiResponse.status = (int)HttpRequest.StatusCode;
                    return (ApiResponse);
                }
            }catch (Exception e){
                ApiResponse.success = false;
                ApiResponse.status = -1;
                return (ApiResponse);
            }
        }

        /*
        public async Task<Response<object>> get_TagsMedia()
        {

        }
        */
    }
}
