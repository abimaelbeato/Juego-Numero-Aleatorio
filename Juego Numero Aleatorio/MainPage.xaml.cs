using Microsoft.Maui.Controls;

namespace AdivinaElNumero
{
    public partial class MainPage : BasePage
    {
        private int numeroSecreto;

        public MainPage()
        {
            InitializeComponent();
            ReiniciarJuego();
        }

        private void OnGuessTapped(object sender, EventArgs e)
        {
            int suposicion;
            if (int.TryParse(entryGuess.Text, out suposicion))
            {
                if (suposicion < numeroSecreto)
                {
                    imgFeedback.Source = "Resources/images/alto.png";
                }
                else if (suposicion > numeroSecreto)
                {
                    imgFeedback.Source = "Resources/images/bajo.png";
                }
                else
                {
                    imgFeedback.Source = "Resources/images/correctoo.png";
                    ReiniciarJuego();
                }
            }
            else
            {
                imgFeedback.Source = "Resources/images/invalido.png";
            }
        }

        private void ReiniciarJuego()
        {
            var random = new Random();
            numeroSecreto = random.Next(1, 101); // Número aleatorio entre 1 y 100
            entryGuess.Text = string.Empty;
            imgFeedback.Source = "Resources/images/empty.png";
        }
    }
}