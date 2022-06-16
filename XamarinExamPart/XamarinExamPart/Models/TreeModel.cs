using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;
using XamarinExamPart.ViewModels;

namespace XamarinExamPart.Models
{
    //Made by Nicolaj
    public class TreeModel : BaseViewModel
    {
        public string No { get; set; }
        public string TreeType { get; set; }
        public String ImagePath { get; set; }
        public string BarCode { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public double HumidityMin { get; set; }
        public double HumidityMax { get; set; }
        public string UserId { get; set; }

        public byte[] Image;

        private ImageSource pictureSource;
        public ImageSource PictureSource
        {
            set
            {
                pictureSource = value;
                OnPropertyChanged();
            }
            get
            {
                return pictureSource;
            }
        }

        /*
        private byte[] picture;

        public byte[] Picture
        {
            get => picture;
            set
            {
                picture = value;
                PictureSource = ImageSource.FromStream(() => new MemoryStream(picture));
            }
        }

        private ImageSource pictureSource;
        public ImageSource PictureSource
        {
            set
            {
                pictureSource = value;
                OnPropertyChanged();
            }
            get
            {
                return pictureSource;
            }
        }
    }
        */


    }
  
}
