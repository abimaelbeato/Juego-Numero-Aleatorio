using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;

namespace AdivinaElNumero
{
    public partial class MainPage : ContentPage
    {
        private int numeroSecreto;
        private int intentos;
        private int rangoMin;
        private int rangoMax;

        public MainPage()
        {
            InitializeComponent();
            CargarRango();
            GenerarNumeroSecreto();
            MostrarMensajeInicial();
        }

        // Cargar el rango desde las preferencias guardadas
        private void CargarRango()
        {
            rangoMin = Preferences.Get("RangoMin", 1);
            rangoMax = Preferences.Get("RangoMax", 100);
        }

        // Generar el número secreto aleatorio dentro del rango
        private void GenerarNumeroSecreto()
        {
            Random random = new Random();
            numeroSecreto = random.Next(rangoMin, rangoMax + 1);
            intentos = 0;
        }

        // Mostrar mensaje inicial con el rango actual
        private void MostrarMensajeInicial()
        {
            lblFeedback.Text = $"Introduce un número entre {rangoMin} y {rangoMax}.";
        }

        // Acción al hacer clic en el botón "Adivinar"
        private void OnSubmitClicked(object sender, EventArgs e)
        {
            if (int.TryParse(entryGuess.Text, out int guess))
            {
                intentos++;
                VerificarNumero(guess);
            }
            else
            {
                lblFeedback.Text = "Por favor, ingresa un número válido.";
            }

            entryGuess.Text = string.Empty;
        }

        // Verificar si el número ingresado es correcto
        private void VerificarNumero(int guess)
        {
            if (guess < numeroSecreto)
            {
                lblFeedback.Text = $"El número es más alto. Intentos: {intentos}";
            }
            else if (guess > numeroSecreto)
            {
                lblFeedback.Text = $"El número es más bajo. Intentos: {intentos}";
            }
            else
            {
                lblFeedback.Text = $"¡Correcto! El número era {numeroSecreto}. Intentos: {intentos}";
                ReiniciarJuego();
            }
        }

        // Reiniciar el juego después de acertar
        private void ReiniciarJuego()
        {
            CargarRango();       // Vuelve a cargar el rango actual por si cambió
            GenerarNumeroSecreto();
            MostrarMensajeInicial();
            entryGuess.Text = string.Empty;  // Limpiar el campo de entrada
        }
    }
}

