using SQLiteXamarin.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaInicio : ContentPage
    {
        ModeloBD bd = new ModeloBD();
        public PaginaInicio()
        {
            InitializeComponent();
        }

        private void discografiaButton_Clicked(object sender, EventArgs e)
        {
            // Navegar a la vista de artistas
            Navigation.PushAsync(new Discografia());
        }

        private void musicaButton_Clicked(object sender, EventArgs e)
        {
            if (bd.Artistas.Any() && bd.Discografia.Any())
            {
                // Navegar a la vista de discografía
                Navigation.PushAsync(new Musica());
            }
            else if(bd.Artistas.Any())
            {
                DisplayAlert("Error 02:LF", "Por favor complete el formulario discografia ya que no hay datos", "Aceptar");
            }
            else
            {
                DisplayAlert("Error 02:LF", "Por favor complete el formulario artista ya que no hay datos", "Aceptar");
            }
        }

        private void artistaButton_Clicked(object sender, EventArgs e)
        {
            // Navegar a la vista de artistas
            Navigation.PushAsync(new Artista());
        }

        private void artista_registro_Clicked(object sender, EventArgs e)
        {
            if (bd.Artistas.Any())
            {
                // Navegar a la vista de RegistroArtista
                Navigation.PushAsync(new RegistroArtistaView());
            }
            else
            {
                DisplayAlert("Error", "No hay registros", "Aceptar");
            }
        }

        private void discografia_registro_Clicked(object sender, EventArgs e)
        {
            if (bd.Discografia.Any())
            {
                // Navegar a la vista de RegistroArtista
                Navigation.PushAsync(new RegistrosDiscografiaView());
            }
            else
            {
                DisplayAlert("Error", "No hay registros", "Aceptar");
            }
        }

        private void musica_registro_Clicked(object sender, EventArgs e)
        {
            if (bd.Discografia.Any()&&bd.Artistas.Any())
            {
                // Navegar a la vista de RegistroArtista
                Navigation.PushAsync(new RegistrosCancionesView());
            }
            else
            {
                DisplayAlert("Error", "No hay registros", "Aceptar");
            }
        }
    }
}
