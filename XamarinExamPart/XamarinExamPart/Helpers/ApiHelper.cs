using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinExamPart.Models;

namespace XamarinExamPart.Helpers
{
    class ApiHelper
    {
        public static async Task<HttpResponseMessage> SendData(TreeModel trm)
        {
            HttpClient httpClient = new HttpClient();

            string APIAddress = "http://10.176.132.159:3000/api/trees";

            httpClient.BaseAddress = new Uri(APIAddress); // Insert your API URL Address here.
            string serializedObject = JsonConvert.SerializeObject(trm);

            HttpContent contentPost = new StringContent(serializedObject, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await httpClient.PostAsync(APIAddress, contentPost);
                return response;
            }
            catch (TaskCanceledException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage();
            }
        }
    }
}
