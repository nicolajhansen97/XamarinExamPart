﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XamarinExamPart.Helpers;
using XamarinExamPart.Models;

//Made by Nicolaj
namespace XamarinExamPart.ViewModels
{
 
    class TreeHistoryViewModel : BaseViewModel
    {
        private ObservableCollection<TreeModel> treeList = PlantCollectionSingleton.getInstance();
        public ObservableCollection<TreeModel> TreeList
        {
            get { return treeList; }
            set { treeList = value; OnPropertyChanged(); }
        }
        public TreeHistoryViewModel()
        {

            //This can do security issues, please fix later.
           // if(TreeList.Count == 0)
           // { 
            Task.Run(async () => await getTrees());
         //   }
        }

        //Gets the trees from a http call to the middleware. It deserialize it to our object.
        async Task getTrees()
        {
            try {

            TreeList.Clear();

            var response = await ApiHelper.GetTreesAsync();

            string responseBody = await response.Content.ReadAsStringAsync();

            var treesToList = JsonConvert.DeserializeObject<List<TreeModel>>(responseBody);
            treesToList.ForEach((i) => TreeList.Add(i));
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
