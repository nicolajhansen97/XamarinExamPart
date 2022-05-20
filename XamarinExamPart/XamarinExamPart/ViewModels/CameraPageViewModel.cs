using XamarinExamPart.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinExamPart.ViewModels
{
    class CameraPageViewModel : BaseViewModel
    {
        public ICommand PickImageCommand { get; }
        public ICommand TakeImageCommand { get; }

        public ICommand ChangeToBarcodeCommand { get; }

        private ImageSource imageSourceString;
        public ImageSource ImageSourceString
        {
            get { return imageSourceString; }
            set { imageSourceString = value; OnPropertyChanged(); }
        }

        private string pictureText = "Take or choose a picture to continue";

        public string PictureText
        {
            get { return pictureText; }
            set { pictureText = value; OnPropertyChanged(); }
        }

        private bool nextEnabled = false;

        public bool NextEnabled
        {
            get { return nextEnabled; }
            set { nextEnabled = value; OnPropertyChanged(); }
        }



        public CameraPageViewModel()
        {
            PickImageCommand = new Command(PickImage);
            TakeImageCommand = new Command(TakeImage);
            ChangeToBarcodeCommand = new Command(ChangeToBarcode);
        }

        async void ChangeToBarcode()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new BarcodeScanPage());
        }

        async void PickImage()
        {

            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pick a photo"
            });

            if (result != null)
            {
                NextEnabled = true;
                PictureText = "Do you like this picture? Then go the next page!";
                var stream = await result.OpenReadAsync();
                ImageSourceString = ImageSource.FromStream(() => stream);
            }

        }

        async void TakeImage()
        {
            var result = await MediaPicker.CapturePhotoAsync();

            if (result != null)
            {
                NextEnabled = true;
                PictureText = "Do you like this picture? Then go the next page!";
                var stream = await result.OpenReadAsync();
                ImageSourceString = ImageSource.FromStream(() => stream);
            }
        }
    }
}
