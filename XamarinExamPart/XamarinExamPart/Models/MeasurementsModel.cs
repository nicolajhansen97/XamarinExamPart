using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinExamPart.Models
{
    public class MeasurementsModel
    {
        public string Treeno { get; set; }
      //  public string Barcode { get; set; }
        public string MeasuermentID { get; set; }
        public double Humidity { get; set; }
        public double Temperature { get; set; }
     //   public bool IsSoilWet { get; set; }
        public DateTime DateOfMes { get; set; }
    }
}
