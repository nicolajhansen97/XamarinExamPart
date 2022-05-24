using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinExamPart.ViewModels;

namespace XamarinExamPart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            var assembly = typeof(RegisterPage);

            InitializeComponent();
            iconImage.Source = ImageSource.FromResource("XamarinExamPart.Assets.Images.Gard.png", assembly);
            this.BindingContext = new RegisterViewModel();
        }
    }
}