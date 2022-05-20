using XamarinExamPart.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace XamarinExamPart.ViewModels

{
    class BarcodeScanPageViewModel : BaseViewModel
    {

        public ICommand ScanBarcodeCommand { get; set; }
        public ICommand NavigateToInformationCommand { get; set; }

        private string barcodeText = "No barcode scanned";

        public string BarcodeText 
        {
            get { return barcodeText; }
            set { barcodeText = value; OnPropertyChanged(); }
        }

        private bool isNextEnabled = false;

        public bool IsNextEnabled
        {
            get { return isNextEnabled; }
            set { isNextEnabled = value; OnPropertyChanged(); }
        }


        public BarcodeScanPageViewModel()
        {
            ScanBarcodeCommand = new Command(scan);
            NavigateToInformationCommand = new Command(NavigateToInformation);
        }

        async void NavigateToInformation()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AdditonalTreeInformationPage());
        }

        async void scan()
        {

            var scan = new ZXingScannerPage();
            await Application.Current.MainPage.Navigation.PushAsync(scan);
            scan.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    BarcodeText = "You scanned the following Barcode: " + result.ToString();
                  
                    if(result != null)
                    {
                        IsNextEnabled = true;
                    }

                    await Application.Current.MainPage.Navigation.PopAsync();
                   
                });
            };
        }
    }
}
