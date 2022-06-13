using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinExamPart.Views;

//Made by Nicolaj
namespace XamarinExamPart.ViewModels
{
    class HumidityPercentViewModel : BaseViewModel
    {
        public ICommand NavigateToAdditionalInformationPageCommand { get; set; }

        private double mininumAlertHumidity;

        public double MininumAlertHumidity
        {
            get { return mininumAlertHumidity; }
            set { mininumAlertHumidity = value; OnPropertyChanged(); ChangeMinimumHumidityText(value); }
        }

        private double maximumAlertHumidity;

        public double MaximumAlertHumidity
        {
            get { return maximumAlertHumidity; }
            set { maximumAlertHumidity = value; OnPropertyChanged(); ChangeMaximumHumidityText(value); }
        }


        private string minimumHumidityAlertText;

        public string MinimumHumidityAlertText
        {
            get { return minimumHumidityAlertText; }
            set { minimumHumidityAlertText = value; OnPropertyChanged(); }
        }

        private string maximumHumidityAlertText;

        public string MaximumHumidityAlertText
        {
            get { return maximumHumidityAlertText; }
            set { maximumHumidityAlertText = value; OnPropertyChanged(); }
        }

        public HumidityPercentViewModel()
        {
            NavigateToAdditionalInformationPageCommand = new Command(NavigateToHumidityPage);
        }

        //Change the minimum humidity text.
        void ChangeMinimumHumidityText(double humidity)
        {
            MinimumHumidityAlertText = "The minimum humidity is now set to " + humidity + "%";
            BaseViewModelMinimumHumidity = humidity;
        }

        //Change the maximum humidity text.
        void ChangeMaximumHumidityText(double humidity)
        {
            MaximumHumidityAlertText = "The maximum humidity is now set to " + humidity + "%";
            BaseViewModelMaximumHumidity = humidity;
        }

        async void NavigateToHumidityPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AdditonalTreeInformationPage());
        }


    }
}
