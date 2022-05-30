using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinExamPart.Views;

//Made by Nicolaj
namespace XamarinExamPart.ViewModels
{
    class TreeTemperatureViewModel : BaseViewModel
    {
        public ICommand NavigateToHumidityPageCommand { get; set; }

        private double mininumAlertTemperature;

        public double MininumAlertTemperature
        {
            get { return mininumAlertTemperature; }
            set { mininumAlertTemperature = value; OnPropertyChanged(); ChangeMinimumTemperatureText(value); }
        }

        private double maximumAlertTemperature;

        public double MaximumAlertTemperature
        {
            get { return maximumAlertTemperature; }
            set { maximumAlertTemperature = value; OnPropertyChanged(); ChangeMaximumTemperatureText(value); }
        }


        private string minimumTemperatureAlertText;

        public string MinimumTemperatureAlertText
        {
            get { return minimumTemperatureAlertText; }
            set { minimumTemperatureAlertText = value; OnPropertyChanged(); }
        }

        private string maximumTemperatureAlertText;

        public string MaximumTemperatureAlertText
        {
            get { return maximumTemperatureAlertText; }
            set { maximumTemperatureAlertText = value; OnPropertyChanged(); }
        }

        public TreeTemperatureViewModel()
        {
            NavigateToHumidityPageCommand = new Command(NavigateToHumidityPage);
        }

        void ChangeMinimumTemperatureText(double temperature)
        {
            MinimumTemperatureAlertText = "The minimum temperature is now set to " + temperature + " degrees";
            BaseViewModelMinimumTemperature = temperature;
        }

        void ChangeMaximumTemperatureText(double temperature)
        {
            MaximumTemperatureAlertText = "The maximum temperature is now set to " + temperature + " degrees";
            BaseViewModelMaximumTemperature = temperature;

        }

        async void NavigateToHumidityPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new HumidityPercentPage());
        }


    }
}
