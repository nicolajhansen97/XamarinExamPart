﻿using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinExamPart.Models
{
    //Made by Nicolaj
    public class TreeModel
    {
        public int id { get; set; } //Primary key, add this when we force this to db.
        public string whichTreeType { get; set; } 

        public string image { get; set; }
        public string barcode { get; set; }
        public string temperatureAlert { get; set; }
        public string humidityAlert { get; set; }

        public string userId { get; set; }

    }

  
}
