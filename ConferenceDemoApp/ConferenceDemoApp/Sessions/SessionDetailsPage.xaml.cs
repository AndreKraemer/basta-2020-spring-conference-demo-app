using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConferenceDemoApp.Sessions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty("SessionId", "id")]
    public partial class SessionDetailsPage : ContentPage
    {

        private ISessionService _sessionService = DependencyService.Get<ISessionService>();
        public SessionDetailsPage()
        {
            InitializeComponent();
        }

        public string SessionId
        {
            set
            {
                if (int.TryParse(Uri.UnescapeDataString(value), out var id))
                {
                    BindingContext = _sessionService.GetSessionAsync(id).Result;
                }
            }
        }
    }
}