using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinExamPart.Helpers;
using XamarinExamPart.Models;

namespace XamarinExamPart.ViewModels
{
    //Made by Nicolaj
    class HomePageViewModel : BaseViewModel
    {
        public ICommand CheckForMessagesCommand { get; set; }
        public ICommand MarkAsHandledCommand { get; set; }

        private MessageModel selectedMessage;

        public MessageModel SelectedMessage
        {
            get { return selectedMessage; }
            set { selectedMessage = value; }
        }

        private ObservableCollection<MessageModel> messageList = MessagesCollectionSingleton.getInstance();
        public ObservableCollection<MessageModel> MessageList
        {
            get { return messageList; }
            set { messageList = value; OnPropertyChanged(); }
        }

        private ObservableCollection<TreeModel> treeList = PlantCollectionSingleton.getInstance();
        public ObservableCollection<TreeModel> TreeList
        {
            get { return treeList; }
            set { treeList = value; OnPropertyChanged(); }
        }

        public HomePageViewModel()
        {
            CheckForMessagesCommand = new Command(RefreshMessageListVoid);
            MarkAsHandledCommand = new Command(MarkAsHandled);

            Task.Run(async () => await RefreshMessageList());

        }

        async Task RefreshMessageList()
        {
                try
                {
                    await Task.Delay(2000);
                    MessageList.Clear();

                    var response = await ApiHelper.GetMessagesAsync();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var messagesToList = JsonConvert.DeserializeObject<List<MessageModel>>(responseBody);

                
                foreach (var tree in TreeList)
                {
                    foreach (var message in messagesToList)
                    {
                        if (tree.BarCode.Equals(message.BarCode) && message.IsHandled == false)
                        {
                            MessageList.Add(message);
                        }
                    }
                }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
        }

        async void RefreshMessageListVoid()
        {
            try
            {

                MessageList.Clear();

                var response = await ApiHelper.GetMessagesAsync();
                string responseBody = await response.Content.ReadAsStringAsync();
                var messagesToList = JsonConvert.DeserializeObject<List<MessageModel>>(responseBody);


                foreach (var tree in TreeList)
                {
                    foreach (var message in messagesToList)
                    {
                        if (tree.BarCode.Equals(message.BarCode) && message.IsHandled == false)
                        {
                            MessageList.Add(message);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        async void MarkAsHandled()
        {
           
                MessageModel msm = new MessageModel();

            try
            {
                // Update the product
                msm.WarNo = SelectedMessage.WarNo;
                msm.BarCode = SelectedMessage.BarCode;
                msm.Warning = SelectedMessage.Warning;
                msm.IsHandled = true;


                var response = await ApiHelper.UpdateProductAsync(msm);
                await RefreshMessageList();
             }
             catch (Exception e)
             {
               await Application.Current.MainPage.DisplayAlert("Error", "The following error has occured: " + e, "Ok");
            }
           }
          }
    }
    

