using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace AdivinaElNumero
{
    public partial class App : Application
    {
        public static int RangoMin { get; set; }
        public static int RangoMax { get; set; }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage (new NivelDificultad());


        }
    }
}
