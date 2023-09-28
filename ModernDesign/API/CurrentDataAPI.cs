using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ModernDesign.API
{
    public class CurrentDataAPI
    {

        public CurrentDataAPI()
        {

        }


        public APIData[] CallApiSync(string stock)
        {

            string apiStart = "https://financialmodelingprep.com/api/v3/quote/";
            string apiEnd = "?limit=1&apikey=94e07214964175f36c3ca22f1f9a5a18";

            string apiUrl = apiStart + stock + apiEnd;

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {

                    var content = response.Content.ReadAsStringAsync().Result;
                    APIData[] result = JsonConvert.DeserializeObject<APIData[]>(content);

                    return result;
                }
                else
                {
                    throw new Exception("API call failed with status code: " + response.StatusCode);
                }
            }
        }


    }
}
