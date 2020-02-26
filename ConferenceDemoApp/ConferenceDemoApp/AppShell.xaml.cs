using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceDemoApp.Sessions;
using ConferenceDemoApp.Speakers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConferenceDemoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("speakers/details", typeof(SpeakerDetailsPage));
            Routing.RegisterRoute("sessions/details", typeof(SessionDetailsPage));
        }
    }
}