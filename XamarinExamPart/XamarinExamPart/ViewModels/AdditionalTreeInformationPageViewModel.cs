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

            TreeList = new ObservableCollection<TreeSort>()
            {
                new TreeSort { TypeOfTree = "Oliven" },
                new TreeSort { TypeOfTree = "Ahorn" },
                new TreeSort { TypeOfTree = "Birke" },
            };
        }

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
                BarCode = BaseViewModelBarcodeHolder
                //image = ?? Tilføj, men how
            };
/*

            TestModel tm = new TestModel
            {
                no = 56,
                name = "Nicolaj",
                price = 99,
                barCode = "000000200000"
            };
*/
           
           var respons = await ApiHelper.CreateTreeAsync(trm); //Check after holiday, and handle messages according to the respons.
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
