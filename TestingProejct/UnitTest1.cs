using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using Xunit;

namespace TestingProejct
{
    //Made by Nicolaj
    public class UnitTest1
    {
        //Here we test the connection, and sees if we are able to get any trees. If we are we expect status code 200.
        [Fact]
        public async void GetTreesConnectionTest()
        {

            //Arrange

            string serverUrl = "http://10.176.132.158:3000/api/Trees";
            HttpClient client = new HttpClient();

            //Act

            HttpResponseMessage response = await client.GetAsync(serverUrl);

            //Assert

            Assert.Equal(200, (int)response.StatusCode);
        }

        //Here we testing creating and a post request through HTTP. We try to create a tree, and exspect 201 as this is the succes code for posting.
        [Fact]
        public async void CreateTree()
        {

            //Arrange
            TreeModel trm = new TreeModel
            {
                BarCode = "400",
                UserId = "UnitTest",
                TempMin = 1,
                TempMax = 9,
                HumidityMin = 11,
                HumidityMax = 99,
                TreeType = "Birke"
            };

            string serverUrl = "http://10.176.132.158:3000/api/Trees";
            HttpClient client = new HttpClient();
            string serializedObject = JsonConvert.SerializeObject(trm);
            HttpContent contentPost = new StringContent(serializedObject, Encoding.UTF8, "application/json");

            //Act
            HttpResponseMessage response = await client.PostAsync(serverUrl, contentPost);

            //Assert

            Assert.Equal(201, (int)response.StatusCode);
        }

        //Testing a unvalid link, then we exspect 404 as this HTTP request should not be allowed.
        [Fact]
        public async void CheckFails()
        {

            //Arrange

            string serverUrl = "http://10.176.132.158:3000/api/Dev1ce";
            HttpClient client = new HttpClient();

            //Act

            HttpResponseMessage response = await client.GetAsync(serverUrl);

            //Assert

            Assert.Equal(404, (int)response.StatusCode);
        }
       }


    public class TreeModel
    {
        public string No { get; set; }
        public string TreeType { get; set; }
        public string ImagePath { get; set; }
        public string BarCode { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public double HumidityMin { get; set; }
        public double HumidityMax { get; set; }
        public string UserId { get; set; }

        public byte[] Image;
    }
}