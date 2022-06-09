using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamarinExamPart.Models;

namespace XamarinExamPart.Helpers
{
    //Singleton that makes it sure, that we only have one instance, if an instance exist, it will just return the instance.
    public class MessagesCollectionSingleton
    {
        private static ObservableCollection<MessageModel> instance = null;

        public static ObservableCollection<MessageModel> getInstance()
        {
            if (instance == null)
            {
                instance = new ObservableCollection<MessageModel>();
            }
            return instance;
        }
    }
}
