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

//Made by Nicolaj
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

        private int NumberOfMeasurementsShownInGraph = 5;

        public ChartPageViewModel()
        {
            Task.Run(async () => await getMesurements());
        }

        //Gets the measurements through http request, then wel sort it, order it, and find the 5 latest only.
        async Task getMesurements()
        {
            try
            {

                MeasurementsList.Clear();

                var response = await ApiHelper.GetMeasurementAsync();
                string responseBody = await response.Content.ReadAsStringAsync();
                var measurementsToList = JsonConvert.DeserializeObject<List<MeasurementsModel>>(responseBody);

                var sortedMeasurements = measurementsToList.FindAll((m) => m.Treeno.Equals(BaseViewModelTreeNo));
                var lastMeasurements = sortedMeasurements.OrderByDescending(x => x.DateOfMes).Take(NumberOfMeasurementsShownInGraph).
                    OrderBy(x => x.DateOfMes).ToList();
               
                lastMeasurements.ForEach((m) => MeasurementsList.Add(m));

                //Creates the chart with temperature, and the measurements ID as parameters.
                ChartHelper cs = new ChartHelper();
                ChartTemp = cs.CreateChart<MeasurementsModel>(lastMeasurements, (m) => (float)m.Temperature, (m) => "ID: " + m.MeasuermentID.ToString());
                ChartHelper cs1 = new ChartHelper();
                ChartHum = cs1.CreateChart<MeasurementsModel>(lastMeasurements, (m) => (float)m.Humidity, (m) => "ID: " + m.MeasuermentID.ToString());


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

       
    }
}