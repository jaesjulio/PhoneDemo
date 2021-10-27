using PhoneAppMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PhoneAppMobile.ViewModels
{
    class MessageViewModel : BaseViewModel
    {
        private int to;
        private string message;

        public MessageViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(to.ToString())
                && !String.IsNullOrWhiteSpace(message);
        }

        public int To
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
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Message newMessage = new Message()
            {
                ToNumber = To,
                TextMessage = Message,

            };

            //await DataStore.AddItemAsync(newMessage);

            //var response = await MessageService.SendMessage(newMessage);
            var response = await MessageService.GetMessages();
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
