using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinExamPart.Helpers;
using XamarinExamPart.Views;

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

        async void ChangeToRegisterPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

        async void Login()
        {
           bool isUserNameEntry = string.IsNullOrEmpty(UsernameEntry);
           bool isPasswordEntry = string.IsNullOrEmpty(PasswordEntry);

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
