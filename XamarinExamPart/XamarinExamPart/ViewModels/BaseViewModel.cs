using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace XamarinExamPart.ViewModels
{
    //Made by Nicolaj - This page is for the OnPropertyChanged.
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
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