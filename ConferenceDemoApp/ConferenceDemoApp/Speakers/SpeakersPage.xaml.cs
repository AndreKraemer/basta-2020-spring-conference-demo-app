﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConferenceDemoApp.Speakers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpeakersPage : ContentPage
    {

        private SpeakersViewModel _viewModel;
        public SpeakersPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new SpeakersViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadItemsCommand.Execute(null);
        }

        private async void SpeakerSelected(object sender, SelectionChangedEventArgs e)
        {
            var id = (e.CurrentSelection.FirstOrDefault() as Speaker)?.Id;
            if (id.HasValue)
            {
               await Shell.Current.GoToAsync($"speakers/details?id={id.Value}");
            }
            
        }
    }
}