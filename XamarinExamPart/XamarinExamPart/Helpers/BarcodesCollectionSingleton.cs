using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamarinExamPart.Models;

namespace XamarinExamPart.Helpers
{
    //Singleton that makes it sure, that we only have one instance, if an instance exist, it will just return the instance.
    public class BarcodesCollectionSingleton
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

