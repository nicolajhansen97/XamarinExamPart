using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using XamarinExamPart.Models;

namespace XamarinExamPart.ViewModels
{
    //Made by Nicolaj - This page is for the OnPropertyChanged.
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public static byte[] BaseViewModelImage;
        public static string BaseViewModelBarcodeHolder = "";
        public static double BaseViewModelMinimumTemperature = 0;
        public static double BaseViewModelMaximumTemperature = 0;
        public static double BaseViewModelMinimumHumidity = 0;
        public static double BaseViewModelMaximumHumidity = 0;

        public static string BaseViewModelTreeNo;

        protected BaseViewModel()
        {

        }

        // Key of behavior, allows the page to be notified when properties of its ViewModel have changed.
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(
        [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName));
        }
    }
}