using System;
using ConferenceDemoApp.Speakers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConferenceDemoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<SpeakerService>();
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
