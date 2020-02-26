using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ConferenceDemoApp.Sessions
{
    public class SessionsSearchHandler: SearchHandler
    {

        private ISessionService _sessionsService = DependencyService.Get<ISessionService>();

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);
            if(string.IsNullOrEmpty(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = _sessionsService.Search(newValue).Result;
            }
        }

        protected async override void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            var id = (item as Session)?.Id;
            if (id.HasValue)
            {
                await Shell.Current.GoToAsync($"sessions/details?id={id.Value}");
            }
        }
    }
}
