﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XamarinExamPart.Models;
using XamarinExamPart.ViewModels;

//Made by Nicolaj
namespace XamarinExamPart.Helpers
{
    class ApiHelper
    {
        //Constants, so we only change it once if the IP changes.
        public static string serverUrl = "http://10.176.132.159:3000/api/"; //School
       // public static string serverUrl = "http://192.168.0.12:3000/api/";
        public static string trees = "trees";
        public static string measurements = "Measuerment";
        public static string devices = "Device";
        public static string messages = "Warning";

        public static HttpClient client { get; set; }

        //Intialize the client, we dont want to do this every time. Now we intialize it once, call it from App.
        public static void InitializeClient()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        //Create the tree async. Makes it JSON and post it to the middleware through Httpclient.
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

        //Gets the tree async. Calls the middleware through HTTP and returns the response.
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

        //Gets the tree async. Calls the middleware through HTTP and returns the response.
        public static async Task<HttpResponseMessage> GetMeasurementAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(serverUrl + measurements);
                response.EnsureSuccessStatusCode();

                return response;

            }
            catch (Exception e)
            {
                return new HttpResponseMessage();
            }
        }
        public static async Task<HttpResponseMessage> GetDevicesAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(serverUrl + devices);
                response.EnsureSuccessStatusCode();

                return response;

            }
            catch (Exception e)
            {
                return new HttpResponseMessage();
            }
        }

        public static async Task<HttpResponseMessage> GetMessagesAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(serverUrl + messages);
                response.EnsureSuccessStatusCode();

                return response;

            }
            catch (Exception e)
            {
                return new HttpResponseMessage();
            }
        }

        public static async Task<MessageModel> UpdateProductAsync(MessageModel msm)
        {

            string serializedObject = JsonConvert.SerializeObject(msm);
            HttpContent contentPost = new StringContent(serializedObject, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(serverUrl + messages + "/" + msm.WarNo, contentPost);

            response.EnsureSuccessStatusCode();

            return msm;
            

        }


    }
}
