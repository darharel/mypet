using Newtonsoft.Json;
using PetitBear.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PetitBear.API
{
    public class SearchController
    {
        HttpClient client;
       // string grant_Type = "password";
        private const string webUrl = App.webUrl;

        public SearchController()
        {
            client = new HttpClient{ MaxResponseContentBufferSize = 256000 };
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form--urlencoded"));

        }

        public async Task<IEnumerable<SupplierModel>> GetItems(SearchModel searchDetails = null)
        {
            //var Token = App.TokenController.GetToken();
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.Result.access_token);
            //try
            //{
            //var response = await client.GetAsync($"{webUrl}?Profession={searchDetails.Proffesion}&amp;Area={searchDetails.Area}");
            try
            {
                var response = await client.GetAsync(webUrl);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string jsonResult = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<SupplierModel>>(jsonResult);

                    }
                    return Enumerable.Empty<SupplierModel>();
                }
                catch { return null; };
            //}
            //catch { return null; }
            //return null;

            

        }
    }
}
