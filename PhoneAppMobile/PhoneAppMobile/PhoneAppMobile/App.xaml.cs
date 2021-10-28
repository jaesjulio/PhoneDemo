using PhoneAppMobile.Services;
using PhoneAppMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhoneAppMobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MessageService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
