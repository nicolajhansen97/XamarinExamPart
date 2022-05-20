using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinExamPart.Models
{
    //Made by Nicolaj
    public class TreeModel
    {
        public int id { get; set; } //Primary key, add this when we force this to db.
        public TreeType whichTreeType { get; set; } //Which treetype, use TreeType as class, which is an Enum with the different trees.

        public string image { get; set; }
        public string barcode { get; set; }
     
    }

  
}
