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
    public partial class FavoritesPage : ContentPage
    {
        private SessionsViewModel _viewModel;
        public FavoritesPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new SessionsViewModel(true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadItemsCommand.Execute(null);
        }

        private async void SessionSelected(object sender, SelectionChangedEventArgs e)
        {
            var id = (e.CurrentSelection.FirstOrDefault() as Session)?.Id;
            if (id.HasValue)
            {
                await Shell.Current.GoToAsync($"sessions/details?id={id.Value}");
            }

        }
    }
}