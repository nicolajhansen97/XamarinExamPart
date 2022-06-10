using XamarinExamPart.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using System.Threading.Tasks;
using ZXing;
using System.Collections.ObjectModel;
using XamarinExamPart.Models;
using XamarinExamPart.Helpers;
using System.Linq;
using Newtonsoft.Json;

//Made by Nicolaj
namespace XamarinExamPart.ViewModels
{
    class MainMenuViewModel : BaseViewModel
    {
        private ObservableCollection<TreeModel> barcodeList = BarcodesCollectionSingleton.getInstance();
        public ObservableCollection<TreeModel> BarcodeList
        {
            get { return barcodeList; }
            set { barcodeList = value; OnPropertyChanged(); }
        }

        private ObservableCollection<DeviceModel> deviceList = DeviceCollectionSingleton.getInstance();
        public ObservableCollection<DeviceModel> DeviceList
        {
            get { return deviceList; }
            set { deviceList = value; OnPropertyChanged(); }
        }
        public ICommand NewTreeCommand { get; }
        public ICommand ScanCommand { get; }

        public MainMenuViewModel()
        {
            NewTreeCommand = new Command(ChangeToNewTreePage);
            ScanCommand = new Command(Scan);
        }

        async void ChangeToNewTreePage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new NewTree());
        }

        async void Scan()
        {

            var scan = new ZXingScannerPage();
            await Application.Current.MainPage.Navigation.PushAsync(scan);
            scan.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.Navigation.PopAsync();
                    await GetInformationAboutTree(result.ToString());
              
                });
            };
        }

        private async Task GetInformationAboutTree(string Barcode)
        {
            try
            {
                if (DeviceList.Count == 0)
                {
                    await getDevices();
                }

                if (BarcodeList.Count == 0 || DeviceList.Count == 0)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Did not find any information paired with this barcode. Try again or contact your system administrator", "Ok");
                }
                else
                {
                    var Tree = BarcodeList.ToList().FindAll((t) => t.BarCode.Equals(Barcode));
                    TreeModel trm = Tree.ElementAt(0);

                    var Device = DeviceList.ToList().FindAll((d) => d.BarCode.Equals(Barcode));
                    DeviceModel dm = Device.ElementAt(0);


                    await Application.Current.MainPage.DisplayAlert("Information", "Tree number: " + trm.No + "\n\nTree type: " + trm.TreeType + "\n\nBarcode: "
                        + trm.BarCode + "\n\nMininimum temperature: " + trm.TempMin + "\n\nMaximum temperature: " + trm.HumidityMax +
                        "\n\nMininimum humidity: " + trm.HumidityMin + "\n\nMaximum humidity: " + trm.HumidityMax + "\n\nRaspberry version: " + dm.RaspberryVer + "\n\nWorking: " + dm.Working, "Ok");
                }
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "The following error has occured: " + e, "Ok");
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

                deviceToList.ForEach((d) => DeviceList.Add(d));

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
