using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ConferenceDemoApp.Speakers
{
    public class SpeakersSearchHandler: SearchHandler
    {

        private ISpeakerService _speakerService = DependencyService.Get<ISpeakerService>();

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);
            if(string.IsNullOrEmpty(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = _speakerService.Search(newValue).Result;
            }
        }

        protected async override void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            var id = (item as Speaker)?.Id;
            if (id.HasValue)
            {
                await Shell.Current.GoToAsync($"speakers/details?id={id.Value}");
            }
        }
    }
}
