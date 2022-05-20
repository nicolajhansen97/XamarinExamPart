using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace XamarinExamPart.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected BaseViewModel()
        {

        }

        // Key of behavior, allows the page to be notified when properties of its VIewModel have changed.
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(
        [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName));
        }
    }
}