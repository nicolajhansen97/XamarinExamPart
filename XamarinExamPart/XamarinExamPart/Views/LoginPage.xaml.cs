using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinExamPart.ViewModels;

namespace XamarinExamPart
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            var assembly = typeof(LoginPage);

            iconImage.Source = ImageSource.FromResource("XamarinExamPart.Assets.Images.Gard.png", assembly);
            this.BindingContext = new LoginViewModel();
        }
    }
}
