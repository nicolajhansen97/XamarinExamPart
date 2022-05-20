using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinExamPart.Helpers;
using XamarinExamPart.Views;

//Made by Nicolaj
namespace XamarinExamPart.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; }
        public ICommand RegisterPageCommand { get; }


        private string usernameEntry;

        public string UsernameEntry
        {
            get { return usernameEntry; }
            set { usernameEntry = value; OnPropertyChanged(); }
        }

        private string passwordEntry;

        public string PasswordEntry
        {
            get { return passwordEntry; }
            set { passwordEntry = value; OnPropertyChanged(); }
        }
        private string imageSourceFront;
        public string ImageSourceFront
        {
            get { return imageSourceFront; }
            set { imageSourceFront = value; OnPropertyChanged(); }
        }




        public LoginViewModel()
        {
            
            LoginCommand = new Command(Login);
            RegisterPageCommand = new Command(ChangeToRegisterPage);


        }

        //Changes the view
        async void ChangeToRegisterPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

        //This handles the login. First we  check if the is any empty Entries, if not then we call LoginUser and wait for the result. If it return true, we are logged in and we change view.
        async void Login()
        {

            if(string.IsNullOrEmpty(UsernameEntry) || string.IsNullOrEmpty(PasswordEntry))
            {
                await Application.Current.MainPage.DisplayAlert("Fejl", "Udfyldt venligst både brugernavn og kodeord!", "Ok");
            }
            else
            {
                //authenticate
               bool result = await Auth.LoginUser(UsernameEntry, passwordEntry);

                if (result)
                {
                await Application.Current.MainPage.Navigation.PushAsync(new MainMenu());
                }
            }
        }
    }
}
