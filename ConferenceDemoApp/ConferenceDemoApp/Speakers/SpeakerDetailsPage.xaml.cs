using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConferenceDemoApp.Speakers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty("SpeakerId", "id")]
    public partial class SpeakerDetailsPage : ContentPage
    {

        private ISpeakerService _speakerService = DependencyService.Get<ISpeakerService>();
        public SpeakerDetailsPage()
        {
            InitializeComponent();
        }

        public string SpeakerId
        {
            set
            {
                if (int.TryParse(Uri.UnescapeDataString(value), out var id))
                {
                    BindingContext = _speakerService.GetSpeakerAsync(id).Result;
                }
            }
        }
    }
}