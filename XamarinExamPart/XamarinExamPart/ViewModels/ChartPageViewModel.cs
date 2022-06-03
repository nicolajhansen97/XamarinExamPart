using Microcharts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinExamPart.Helpers;
using XamarinExamPart.Models;
using Entry = Microcharts.ChartEntry;

namespace XamarinExamPart.ViewModels
{
    class ChartPageViewModel : BaseViewModel
    {
        private ObservableCollection<MeasurementsModel> measurementsList = MeasurementsCollectionSingleton.getInstance();
        public ObservableCollection<MeasurementsModel> MeasurementsList
        {
            get { return measurementsList; }
            set { measurementsList = value; OnPropertyChanged(); }
        }

        private Chart chartTemp;

        public Chart ChartTemp
        {
            get { return chartTemp; }
            set { chartTemp = value; OnPropertyChanged(); }
        }

        private Chart chartHum;

        public Chart ChartHum
        {
            get { return chartHum; }
            set { chartHum = value; OnPropertyChanged(); }
        }


        public ChartPageViewModel()
        {
            Task.Run(async () => await getMesurements());
        }

        async Task getMesurements()
        {
            try
            {

                MeasurementsList.Clear();

                var response = await ApiHelper.GetMeasurementAsync();
                string responseBody = await response.Content.ReadAsStringAsync();
                var measurementsToList = JsonConvert.DeserializeObject<List<MeasurementsModel>>(responseBody);

                var sortedMeasurements = measurementsToList.FindAll((m) => m.Barcode == BaseViewModelTreeBarCode);
                sortedMeasurements.ForEach((m) => MeasurementsList.Add(m));

                ChartHelper cs = new ChartHelper();
                ChartTemp = cs.CreateChart<MeasurementsModel>(sortedMeasurements, (m) => (float)m.Temperature, (m) => "ID: " + m.MeasuermentID.ToString());
                ChartHelper cs1 = new ChartHelper();
                ChartHum = cs1.CreateChart<MeasurementsModel>(sortedMeasurements, (m) => (float)m.Humidity, (m) => "ID: " + m.MeasuermentID.ToString());


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

       
    }
}