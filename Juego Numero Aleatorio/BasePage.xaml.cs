using Microsoft.Maui.Controls;

namespace AdivinaElNumero
{
    public partial class BasePage : ContentPage
    {
        public BasePage()
        {
            InitializeComponent();
            ReproducirMusicaFondo();
        }

        private void ReproducirMusicaFondo()
        {
            mediaElement.Play();
        }

        private void MediaElement_MediaEnded(object sender, EventArgs e)
        {
            mediaElement.Stop();
            mediaElement.Play();
        }
    }
}