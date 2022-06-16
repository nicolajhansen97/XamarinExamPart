using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinExamPart.Helpers;
using XamarinExamPart.Models;
using XamarinExamPart.Views;

//Made by Nicolaj
namespace XamarinExamPart.ViewModels
{
 
    class TreeHistoryViewModel : BaseViewModel
    {
        public ICommand ChangeToChartPageCommand { get; }

        private ObservableCollection<TreeModel> treeList = PlantCollectionSingleton.getInstance();
        public ObservableCollection<TreeModel> TreeList
        {
            get { return treeList; }
            set { treeList = value; OnPropertyChanged(); }
        }

        private ObservableCollection<TreeModel> barcodeList = BarcodesCollectionSingleton.getInstance();
        public ObservableCollection<TreeModel> BarcodeList
        {
            get { return barcodeList; }
            set { barcodeList = value; OnPropertyChanged(); }
        }

        private TreeModel selectedTree;

        public TreeModel SelectedTree
        {
            get { return selectedTree; }
            set { selectedTree = value; }
        }

        public TreeHistoryViewModel()
        {
           ChangeToChartPageCommand = new Command(ChangeToChartPage);

            //This can do security issues, please fix later.
            // if(TreeList.Count == 0)
            // { 
            Task.Run(async () => await getTrees());
         //   }
        }

        async void ChangeToChartPage()
        {
            BaseViewModelTreeNo = SelectedTree.No;
            await Application.Current.MainPage.Navigation.PushAsync(new ChartPage());
        }

        //Gets the trees from a http call to the middleware. It deserialize it to our object.
        async Task getTrees()
        {
            try {

            TreeList.Clear();

            var response = await ApiHelper.GetTreesAsync();
            string responseBody = await response.Content.ReadAsStringAsync();
            var treesToList = JsonConvert.DeserializeObject<List<TreeModel>>(responseBody);
  

            //Find all that match the user id of the current user, we dont want to see trees for other gartners. 
            var sortedTrees = treesToList.FindAll((t) => t.UserId == Auth.GetCurrentUserId());

             sortedTrees.ForEach((t) => t.PictureSource = t.PictureSource = ImageSource.FromStream(() => new MemoryStream(t.Image)));
             sortedTrees.ForEach((t) => TreeList.Add(t));
             treesToList.ForEach((b) => BarcodeList.Add(b));

            


            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
