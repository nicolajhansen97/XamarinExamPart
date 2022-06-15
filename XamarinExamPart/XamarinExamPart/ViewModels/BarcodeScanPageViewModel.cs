using XamarinExamPart.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using System.Collections.ObjectModel;
using XamarinExamPart.Models;
using XamarinExamPart.Helpers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;


//Made by Nicolaj
namespace XamarinExamPart.ViewModels
{
    class BarcodeScanPageViewModel : BaseViewModel
    {
        private ObservableCollection<DeviceModel> deviceList = DeviceCollectionSingleton.getInstance();
        public ObservableCollection<DeviceModel> DeviceList
        {
            get { return deviceList; }
            set { deviceList = value; OnPropertyChanged(); }
        }

        public List<TreeModel> BarCodeList = new List<TreeModel>();

        public ICommand ScanBarcodeCommand { get; set; }
        public ICommand NavigateToInformationCommand { get; set; }

        private string barcodeText = "No barcode scanned";

        public string BarcodeText 
        {
            get { return barcodeText; }
            set { barcodeText = value; OnPropertyChanged(); }
        }

        private bool isNextEnabled = false;
        private bool isBarCodeEligle = false;

        public bool IsNextEnabled
        {
            get { return isNextEnabled; }
            set { isNextEnabled = value; OnPropertyChanged(); }
        }

        public string PlaneBarcode = "";
        public bool IsUsed;


        public BarcodeScanPageViewModel()
        {
            ScanBarcodeCommand = new Command(Scan);
            NavigateToInformationCommand = new Command(NavigateToInformation);
        }

        //Changes the view. It also check if the barcode is used, if its used you can go further, as its allready paired.
        async void NavigateToInformation()
        {
            IsUsed = false;

            await getDevices();
            BarCodeList.Clear();
            BarCodeList = BarcodesCollectionSingleton.getInstance().ToList();

            foreach (var device in DeviceList)
            {
                if(PlaneBarcode == device.BarCode)
                {
                    foreach (var barcode in BarCodeList)
                    {
                        if(PlaneBarcode == barcode.BarCode)
                        {
                            IsUsed = true;
                            break;
                        }
                    }
                }
            }

            if (IsUsed == false)
            {
                BaseViewModelBarcodeHolder = PlaneBarcode;
                isBarCodeEligle = true;
                await Application.Current.MainPage.Navigation.PushAsync(new TreeTemperaturePage());
            }

            if (isBarCodeEligle == false)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "The barcode you scanned, is not in the database or is allready paired! " +
                    "Please try again or contact your system administrator!", "OK");
            }
         }

        async Task getDevices()
        {
            try
            {

                DeviceList.Clear();

                var response = await ApiHelper.GetDevicesAsync();
                string responseBody = await response.Content.ReadAsStringAsync();
                var deviceToList = JsonConvert.DeserializeObject<List<DeviceModel>>(responseBody);

                //Find all that match the user id of the current user, we dont want to see trees for other gartners. 
                //var sortedBarcodes = deviceToList.FindAll((d) => d.Ba == Auth.GetCurrentUserId());

                deviceToList.ForEach((d) => DeviceList.Add(d));

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
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
                        isBarCodeEligle = false;
                    }

                    await Application.Current.MainPage.Navigation.PopAsync();
                   
                });
            };
        }
    }
}
