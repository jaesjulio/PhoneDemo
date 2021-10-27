using PhoneAppMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PhoneAppMobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}