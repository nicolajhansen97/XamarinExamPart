using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XamarinExamPart.Models;
using XamarinExamPart.ViewModels;

namespace XamarinExamPart.Helpers
{
    class ApiHelper
    {

        // public static string serverUrl = "http://10.176.132.158:3000/api/";
        public static string serverUrl = "http://192.168.0.12:3000/api/";
        public static string trees = "trees";
        public static HttpClient client { get; set; }

        public static void InitializeClient()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public static async Task<HttpResponseMessage> CreateTreeAsync(TreeModel trm)
        {
            string serializedObject = JsonConvert.SerializeObject(trm);
            HttpContent contentPost = new StringContent(serializedObject, Encoding.UTF8, "application/json");

            try { 
            HttpResponseMessage response = await client.PostAsync(serverUrl + trees, contentPost);
            response.EnsureSuccessStatusCode();

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

        public static async Task<HttpResponseMessage> GetTreesAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(serverUrl + trees);
                response.EnsureSuccessStatusCode();
                
                return response;

            }
            catch (Exception e)
            {
                return new HttpResponseMessage();
            }
        }
    }
}