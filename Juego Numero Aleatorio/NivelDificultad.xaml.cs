using Microsoft.Maui.Controls;

namespace AdivinaElNumero
{
    public partial class NivelDificultad : ContentPage
    {
        public NivelDificultad()
        {
            InitializeComponent();
        }

        private async void OnEasyTapped(object sender, EventArgs e)
        {
            Preferences.Set("RangoMin", 1);
            Preferences.Set("RangoMax", 50);
            await Navigation.PushAsync(new MainPage());
        }

        private async void OnMediumTapped(object sender, EventArgs e)
        {
            Preferences.Set("RangoMin", 1);
            Preferences.Set("RangoMax", 100);
            await Navigation.PushAsync(new MainPage());
        }

        private async void OnHardTapped(object sender, EventArgs e)
        {
            Preferences.Set("RangoMin", 1);
            Preferences.Set("RangoMax", 500);
            await Navigation.PushAsync(new MainPage());
        }
    }
}

