using PhoneAppMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PhoneAppMobile.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {
        public ObservableCollection<Message> Messages { get; }
        public Command LoadItemsCommand { get; }

        public HistoryViewModel()
        {
            Messages = new ObservableCollection<Message>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Messages.Clear();
                var items = await MessageService.GetMessages();
                foreach (var item in items)
                {
                    Messages.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
