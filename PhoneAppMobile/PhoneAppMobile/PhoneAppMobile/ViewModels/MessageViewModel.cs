using PhoneAppMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PhoneAppMobile.ViewModels
{
    class MessageViewModel : BaseViewModel
    {
        private string to;
        private string message;

        public MessageViewModel()
        {
            SaveCommand = new Command(OnSave);
        }

        public string To
        {
            get => to;
            set => SetProperty(ref to, value);
        }

        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }

        public Command SaveCommand { get; }


        private async void OnSave()
        {
            if(string.IsNullOrWhiteSpace(To) || string.IsNullOrWhiteSpace(Message))
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Please write a message", "Ok");
            }
            Message newMessage = new Message()
            {
                ToNumber = To,
                TextMessage = Message,
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            var response = await MessageService.SendMessage(newMessage);

            if (response.ExecutedSuccesfully)
            {
                Message = string.Empty;
                To = string.Empty;

                await Application.Current.MainPage.DisplayAlert("Alert", "Message Sent!", "Ok");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Please try again later", "Ok");
            }
        }
    }
}
