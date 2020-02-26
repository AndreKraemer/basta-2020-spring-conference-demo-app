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
    public partial class SpeakerDetailsPage : ContentPage
    {
        public SpeakerDetailsPage()
        {
            InitializeComponent();
        }
    }
}