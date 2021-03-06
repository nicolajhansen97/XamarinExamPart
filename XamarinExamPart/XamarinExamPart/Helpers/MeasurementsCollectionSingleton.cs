using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamarinExamPart.Models;

//Made by Nicolaj
namespace XamarinExamPart.Helpers
{
    //Singleton that makes it sure, that we only have one instance, if an instance exist, it will just return the instance.
    public class MeasurementsCollectionSingleton
    {
        private static ObservableCollection<MeasurementsModel> instance = null;

        public static ObservableCollection<MeasurementsModel> getInstance()
        {
            if (instance == null)
            {
                instance = new ObservableCollection<MeasurementsModel>();
            }
            return instance;
        }
    }
}
