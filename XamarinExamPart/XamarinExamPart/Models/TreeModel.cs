using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinExamPart.Models
{
    //Made by Nicolaj
    public class TreeModel
    {
        public int No { get; set; } //Primary key, add this when we force this to db.
        public string TreeType { get; set; } 
      //  public ImageSource image { get; set; }
      public String ImagePath { get; set; }
        public string BarCode { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public double HumidityMin { get; set; }
        public double HumidityMax { get; set; }

        public string UserId { get; set; }

    }

    public class TestModel
    {
        public int no { get; set; } //Primary key, add this when we force this to db.
        public string name { get; set; }
        //  public ImageSource image { get; set; }
        public int price { get; set; }
        public string barCode { get; set; }
    }

  
}
