using XamarinExamPart.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;


//Made by Nicolaj
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

        public string PlaneBarcode { get; set; }


        public BarcodeScanPageViewModel()
        {
            ScanBarcodeCommand = new Command(Scan);
            NavigateToInformationCommand = new Command(NavigateToInformation);
        }

        //Changes the view.
        async void NavigateToInformation()
        {
            BaseViewModelBarcodeHolder = PlaneBarcode;
            await Application.Current.MainPage.Navigation.PushAsync(new TreeTemperaturePage());
        }

        //Uses the Zxing Nugget Package for scanning barcodes. This return a barcode, if a barcode is scanned.
        async void Scan()
        {

            var scan = new ZXingScannerPage();
            await Application.Current.MainPage.Navigation.PushAsync(scan);
            scan.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    PlaneBarcode = result.ToString();
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
