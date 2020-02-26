using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ConferenceDemoApp.Speakers
{
    public class SpeakersViewModel: INotifyPropertyChanged
    {
        private bool _isLoading;
        private ISpeakerService _speakerService = DependencyService.Get<ISpeakerService>();

        public SpeakersViewModel()
        {
            Speakers = new ObservableCollection<Speaker>();
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


        public ObservableCollection<Speaker> Speakers { get; set; }

        async Task ExecuteLoadItemsCommand()
        {
            IsLoading = true;
            try
            {
                var items = await _speakerService.GetSpeakersAsync();
                Speakers.Clear();
                foreach (var speaker in items)
                {
                    Speakers.Add(speaker);
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
