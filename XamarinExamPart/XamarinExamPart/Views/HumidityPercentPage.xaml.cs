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
    public partial class HumidityPercentPage : ContentPage
    {
        public HumidityPercentPage()
        {
            InitializeComponent();
            this.BindingContext = new HumidityPercentViewModel();
        }
    }
}