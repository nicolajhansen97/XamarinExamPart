using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinExamPart.Models
{
    
    //Made by Nicolaj
    public class MessageModel
    {
        public string WarNo { get; set; }
        public string BarCode { get; set; }
        public string Warning { get; set; }

        public bool IsHandled { get; set; }
    }
}
