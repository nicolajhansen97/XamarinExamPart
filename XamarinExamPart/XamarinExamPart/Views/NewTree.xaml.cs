using XamarinExamPart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinExamPart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTree : ContentPage
    {
        public NewTree()
        {
            var assembly = typeof(NewTree);

            InitializeComponent();
            TreeImage.Source = ImageSource.FromResource("XamarinExamPart.Assets.Images.OlivenTree.png", assembly);
            this.BindingContext = new NewTreeViewModel();
        }
    }
}