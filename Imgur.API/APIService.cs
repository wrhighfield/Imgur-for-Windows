using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.API
{
    public class APIService{





        private HttpClient Client;
        private string ClientID;
        private string UrlBase;

        public APIService(string clientid){

            ClientID = clientid;

            //Set Http Headers
            InitalizeHTTPClient();

        }


        private void InitalizeHTTPClient(){
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("Authorization", "Client-ID ");
        }

        public void get_ApiStatus(){
            
        }



        }
    }
