using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;


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
                    lblFeedback.Text = "Demasiado bajo, intenta nuevamente.";
                }
                else if (suposicion > numeroSecreto)
                {
                    lblFeedback.Text = "Demasiado alto, intenta nuevamente.";
                }
                else
                {
                    lblFeedback.Text = "¡Correcto! Has adivinado el número.";
                    ReiniciarJuego();
                }
            }
            else
            {
                lblFeedback.Text = "Por favor, ingresa un número válido.";
            }
        }

        private void ReiniciarJuego()
        {
            var random = new Random();
            numeroSecreto = random.Next(1, 101); // Número aleatorio entre 1 y 100
            entryGuess.Text = string.Empty;
            lblFeedback.Text = string.Empty;
        }
    }
}