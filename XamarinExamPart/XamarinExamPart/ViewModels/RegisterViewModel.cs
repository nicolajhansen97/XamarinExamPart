using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinExamPart.Helpers;

namespace XamarinExamPart.ViewModels
{
    class RegisterViewModel : BaseViewModel
    {
        public ICommand RegisterCommand { get; }


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

        private string vertificationCode;

        public string VertificationCode
        {
            get { return vertificationCode; }
            set { vertificationCode = value; }
        }




        public RegisterViewModel()
        {

            RegisterCommand = new Command(Register);

        }

        async void Register()
        {

            string vertificationChecker = "9999"; // This is only temperary. Find a better solution later.

            if (string.IsNullOrEmpty(UsernameEntry) || string.IsNullOrEmpty(PasswordEntry) )
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill out both e-mail and password!", "Ok");
            }
            else
            {
                if(!VertificationCode.Equals(vertificationChecker))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "The vertificication code is wrong, please try again or contact the system administrator.", "Ok");
                }
                //authenticate
                bool result = await Auth.RegisterUser(UsernameEntry, PasswordEntry);

                if (result)
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                }
            }
        }
    }
}
    