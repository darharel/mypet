using Newtonsoft.Json;
using PetitBear.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PetitBear.Services
{
    public class RestService
    {
        HttpClient client;
        string grant_Type = "password";
        private const string webUrl = App.webUrl;

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form--urlencoded"));
        }

        public async Task<Token> Login(User user)
        {
            //setting u the format of the string
            var postData = new List<KeyValuePair<string, string>>();
            // setting the data inside the json string
            postData.Add(new KeyValuePair<string, string>("grant_type", grant_Type));
            postData.Add(new KeyValuePair<string, string>("username", user.UserName));
            postData.Add(new KeyValuePair<string, string>("password", user.Password));
            var content = new FormUrlEncodedContent(postData);

            var webUrl = "https://api.myjson.com/bins/qw7ne";

            var response = await PostReponseLogin<Token>(webUrl, content);
            DateTime dt = new DateTime();
            dt = DateTime.Today;
            response.expire_date = dt.AddSeconds(response.expire_in);
            return response;
        }

        public async Task<Token> PostReponseLogin<Task>(string webUrl, FormUrlEncodedContent content)
        {
            var response = await client.PostAsync(webUrl, content);
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<Token>(jsonResult);
            return responseObject;
        }

        public async Task<Token> PostResponseLogin<Task>(string webUrl, string jsonString)
        {
            var Token = App.TokenController.GetToken();
            string contentType = "application/json";
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.Result.access_token);
            try
            { 
                var result = await client.PostAsync(webUrl, new StringContent(jsonString, Encoding.UTF8, contentType));
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResult = result.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var contentResp = JsonConvert.DeserializeObject<Token>(jsonResult);
                        return contentResp;
                    }
                    catch { return null; };
                }
            }
            catch { return null; };
            return null;
        }

        public async Task<Token> GetReponseLogin<Task>(string webUrl, string jsonString)
        {
            var Token = App.TokenController.GetToken();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.Result.access_token);
            try
            {
                var response = await client.GetAsync(webUrl);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResult = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var contentResp = JsonConvert.DeserializeObject<Token>(jsonResult);
                        return contentResp;
                    }
                    catch { return null; };
                }
            }
            catch { return null; };
            return null;
        }



        public async Task<Token> GetAllSpecificTypeList<Task>(string webUrl, string jsonString)
        {
            var Token = App.TokenController.GetToken();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.Result.access_token);
            try
            {
                var response = await client.GetAsync(webUrl);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResult = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var contentResp = JsonConvert.DeserializeObject<Token>(jsonResult);
                        return contentResp;
                    }
                    catch { return null; };
                }
            }
            catch { return null; };
            return null;
        }




    }
}
