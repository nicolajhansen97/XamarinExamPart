using XamarinExamPart.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinExamPart.Helpers;
using Newtonsoft.Json;
using XamarinExamPart.Models;
using System.Collections.ObjectModel;

//Made by Nicolaj

namespace XamarinExamPart.ViewModels
{

    
    class NewTreeViewModel : BaseViewModel
    {
        public ICommand NavigateToTakePictureCommand { get; }
        public NewTreeViewModel()
        {
            NavigateToTakePictureCommand = new Command(NavigateToTakePicture);
        }

        async void NavigateToTakePicture()
        {

            await Application.Current.MainPage.Navigation.PushAsync(new CameraPage());

            //await Application.Current.MainPage.Navigation.PushAsync(new AdditonalTreeInformationPage());
        }
    }
}
