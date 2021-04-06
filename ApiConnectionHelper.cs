using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiConnectionLibrary
{
    public class ApiConnectionHelper<T>
    {
        public static async Task<T> GetAsync(string UrlEndPoint,string schema, string authorizationToken)
        {
            T result;
            using (var httpClient = new HttpClient())
            {
                if (!string.IsNullOrEmpty(schema) && !string.IsNullOrEmpty(authorizationToken))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(schema, authorizationToken);
                    
                }
                using (var response = await httpClient.GetAsync($"{UrlEndPoint}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<T>(apiResponse);
                }
            }
            return result;
        }


        public static async Task<T> PostAsync(ConnectApiModel model)
        {
            T result;
            using (var httpClient = new HttpClient())
            {
                if (!string.IsNullOrEmpty(model.Schema) && !string.IsNullOrEmpty(model.AuthorizationToken))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(model.Schema, model.AuthorizationToken);

                }
               

                StringContent content = new StringContent(JsonConvert.SerializeObject(model.Parameters), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(model.UrlEndPoint, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<T>(apiResponse);
                }
            }
            return result;
        }
    }
}
