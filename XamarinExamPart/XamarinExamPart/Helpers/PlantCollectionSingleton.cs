using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamarinExamPart.Models;

namespace XamarinExamPart.Helpers
{
    public class PlantCollectionSingleton
    {
        private static ObservableCollection<TreeModel> instance = null;

        public static ObservableCollection<TreeModel> getInstance()
        {
            if (instance == null)
            {
                instance = new ObservableCollection<TreeModel>();
            }
            return instance;
        }
    }
}