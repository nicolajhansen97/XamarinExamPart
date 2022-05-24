using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinExamPart.Helpers;
using XamarinExamPart.Models;

namespace XamarinExamPart.ViewModels
{
    class AdditionalTreeInformationPageViewModel : BaseViewModel
    {
        public ICommand CreateTreeCommand { get; set; }
        public ObservableCollection<TreeSort> TreeList { get; set; }

        public TreeSort SelectedTree { get; set; }

        private double currentAlertTemperature;

        public double CurrentAlertTemperature
        {
            get { return currentAlertTemperature; }
            set { currentAlertTemperature = value; OnPropertyChanged(); ChangeTemperatureText(value); }
        }

        private double currentHumidityPercent;

        public double CurrentHumidityPercent
        {
            get { return currentHumidityPercent; }
            set { currentHumidityPercent = value; OnPropertyChanged(); ChangeHumidityText(value); }
        }

        private string temperatureAlertText = "Choose the alert temperature for the plant";

        public string TemperatureAlertText
        {
            get { return temperatureAlertText; }
            set { temperatureAlertText = value; OnPropertyChanged(); }
        }

        private string humidityAlertText = "Choose the humiditypercent alert for the plant";

        public string HumidityAlertText
        {
            get { return humidityAlertText; }
            set { humidityAlertText = value; OnPropertyChanged(); }
        }


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

       void ChangeTemperatureText(double temperature)
        {
            TemperatureAlertText = "The tempareturealert is now set to start at " + temperature + " degrees";
        }

        void ChangeHumidityText(double humidity)
        {
            HumidityAlertText = "The humidityalert is now set to start at " + humidity + "%";
        }

        void CreateTree()
        {
            TreeModel trm = new TreeModel
            {
                //id =
                whichTreeType = SelectedTree.TypeOfTree,
                //image = ??
                barcode = BaseViewModelBarcodeHolder,
                temperatureAlert = CurrentAlertTemperature.ToString(),
                humidityAlert = CurrentHumidityPercent.ToString(),
                userId = Auth.GetCurrentUserId()
            };
        }
    }
}
