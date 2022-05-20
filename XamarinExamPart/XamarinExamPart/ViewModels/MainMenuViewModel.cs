using XamarinExamPart.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinExamPart.ViewModels
{
    class MainMenuViewModel : BaseViewModel
    {
        public ICommand NewTreeCommand { get; }

        public MainMenuViewModel()
        {
            NewTreeCommand = new Command(ChangeToNewTreePage);
        }

        async void ChangeToNewTreePage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new NewTree());
        }
    }
}
