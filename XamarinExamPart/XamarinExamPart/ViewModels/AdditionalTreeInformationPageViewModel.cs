using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
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
    class AdditionalTreeInformationPageViewModel : BaseViewModel
    {
        public ICommand CreateTreeCommand { get; set; }
        public ObservableCollection<TreeSort> TreeList { get; set; }

        public TreeSort SelectedTree { get; set; }

    
        public AdditionalTreeInformationPageViewModel()
        {
            CreateTreeCommand = new Command(CreateTree);

            //Our list of trees. The plan was Enum, but didnt seems to work in the Picker we use. We will check into this later.
            TreeList = new ObservableCollection<TreeSort>()
            {
                new TreeSort { TypeOfTree = "Oliven" },
                new TreeSort { TypeOfTree = "Ahorn" },
                new TreeSort { TypeOfTree = "Birke" },
            };
        }
        

        //Creates the tree. Creates a object of the model, which we send through the HTTP call to the middleware.
        async void CreateTree()
        {
            TreeModel trm = new TreeModel
            {
                TreeType = SelectedTree.TypeOfTree,
                HumidityMin = BaseViewModelMinimumHumidity,
                HumidityMax = BaseViewModelMaximumHumidity,
                TempMin = BaseViewModelMinimumTemperature,
                TempMax = BaseViewModelMaximumTemperature,
                UserId = Auth.GetCurrentUserId(),
                BarCode = BaseViewModelBarcodeHolder,
               // Picture = BaseViewModelImage
            };

           //If response is 201 we change the page, if its not 201 then we know its not created succesfully.
           var respons = await ApiHelper.CreateTreeAsync(trm); 
            if((int)respons.StatusCode == 201)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new MainMenu());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "An error has accured: " +  respons.StatusCode, "Ok");
            }
        }




    }
}
