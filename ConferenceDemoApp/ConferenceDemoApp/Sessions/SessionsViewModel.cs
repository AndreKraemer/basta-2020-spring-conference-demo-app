using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ConferenceDemoApp.Sessions
{
    public class SessionsViewModel : INotifyPropertyChanged
    {
        private readonly bool _showOnlyFavorites;
        private bool _isLoading;
        private ISessionService _sessionsService = DependencyService.Get<ISessionService>();

        public SessionsViewModel(bool showOnlyFavorites = false)
        {
            _showOnlyFavorites = showOnlyFavorites;
            Sessions = new ObservableCollection<Session>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }

        public Command LoadItemsCommand { get; set; }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();

            }
        }


        public ObservableCollection<Session> Sessions { get; set; }

        async Task ExecuteLoadItemsCommand()
        {
            IsLoading = true;
            try
            {
                IList<Session> items;
                if (_showOnlyFavorites)
                {
                    items = await _sessionsService.GetFavoritesAsync();
                }
                else
                {
                    items = await _sessionsService.GetSessionsAsync();

                }
                Sessions.Clear();
                foreach (var session in items)
                {
                    Sessions.Add(session);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsLoading = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
