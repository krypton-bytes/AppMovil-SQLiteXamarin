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
    public partial class Musica : ContentPage
    {
        ModeloBD bd = new ModeloBD();
        public Musica()
        {
            InitializeComponent();
            MostrarArtista();
            MostrarDiscografia();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                DisplayAlert("Error 01:LC", "Por favor complete todos los campos obligatorios antes de enviar el formulario", "Aceptar");
            }
            else if (pckArtista.SelectedIndex == -1)
            {
                DisplayAlert("Error", "Por favor seleccione un artista", "Aceptar");
            }
            else if (pckDiscografia.SelectedIndex == -1)
            {
                DisplayAlert("Error", "Por favor seleccione una discografía", "Aceptar");
            }
            else
            {
                // Consulta para buscar registros con los mismos valores que se intenta insertar
                var existingCancion = bd.Canciones.FirstOrDefault(a => a.Nombre.ToLower() == txtNombre.Text.ToLower() && a.ArtistaID == pckArtista.SelectedIndex && a.DiscografiaID == pckDiscografia.SelectedIndex);
                if (existingCancion != null)
                {
                    // Si se encuentra un registro igual, se muestra una alerta
                    DisplayAlert("Error", "Ya existe un registro con los mismos valores", "Aceptar");
                    txtNombre.Text = string.Empty;
                    pckArtista.SelectedItem = null;
                    pckDiscografia.SelectedItem = null;
                }
                else
                {
                    // Si no se encuentra un registro igual, se inserta el registro en la base de datos
                    CancionModel cancion = new CancionModel
                    {
                        Nombre = txtNombre.Text,
                        ArtistaID = pckArtista.SelectedIndex,
                        DiscografiaID = pckDiscografia.SelectedIndex
                    };
                    bd.Canciones.Add(cancion);
                    bd.SaveChangesAsync();
                    //Comprueba peticion
                    if (bd.Canciones.Any(a => a.Nombre == cancion.Nombre && a.ArtistaID == cancion.ArtistaID && a.DiscografiaID == cancion.DiscografiaID))
                    {
                        DisplayAlert("Peticion atendida", "Datos guardados con exito, datos:" + cancion.Nombre + " " + cancion.ArtistaID + " " + cancion.DiscografiaID, "Aceptar");
                        Navigation.PushAsync(new PaginaInicio());
                    }
                    else
                    {
                        DisplayAlert("Peticion no atendida", "Ocurrio un error compruebelo porfavor", "Aceptar");
                        pckArtista.SelectedItem = null;
                        pckDiscografia.SelectedItem = null;
                    }
                }
            }
        }


        private void MostrarArtista()
        {
            foreach (var item in bd.Artistas)
            {
                pckArtista.Items.Add(item.NombreArtista);
            }

            if (pckArtista.Items.Count > 0)
            {
                pckArtista.SelectedIndex = 0;
            }
        }

        private void MostrarDiscografia()
        {
            foreach (var item in bd.Discografia)
            {
                pckDiscografia.Items.Add(item.Nombre);
            }

            if (pckDiscografia.Items.Count > 0)
            {
                pckDiscografia.SelectedIndex = 0;
            }
        }

    }
}