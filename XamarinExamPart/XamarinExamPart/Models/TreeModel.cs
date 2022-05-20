using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinExamPart.Models
{
    public class TreeModel
    {
        public int id { get; set; } //Primary key, add this when we force this to db.
        public TreeType whichTreeType { get; set; }

        public string image { get; set; }
        public string barcode { get; set; }
     
    }

  
}
