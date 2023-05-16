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
    public partial class Artista : ContentPage
    {
        ModeloBD bd = new ModeloBD();
        public Artista()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Verifica si los campos estan vacios
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrEmpty(txtNombreArtista.Text))
            {
                DisplayAlert("Error 01:LC", "Por favor complete todos los campos obligatorios antes de enviar el formulario", "Aceptar");
            }
            else
            {
                // Consulta para buscar registros con los mismos valores que se intenta insertar
                var existingArtista = bd.Artistas.FirstOrDefault(a => a.Nombre.ToLower() == txtNombre.Text.ToLower() && a.NombreArtista.ToLower() == txtNombreArtista.Text.ToLower());

                if (existingArtista != null)
                {
                    // Si se encuentra un registro igual, se muestra una alerta
                    DisplayAlert("Error", "Ya existe un registro con los mismos valores", "Aceptar");
                    txtNombre.Text = string.Empty;
                    txtNombreArtista.Text = string.Empty;
                }
                else
                {
                    // Si no se encuentra un registro igual, se inserta el registro en la base de datos
                    ArtistaModel artista = new ArtistaModel
                    {
                        Nombre = txtNombre.Text,
                        NombreArtista = txtNombreArtista.Text
                    };
                    bd.Artistas.Add(artista);
                    bd.SaveChanges();
                    //Comprueba peticion
                    if (bd.Artistas.Any(a => a.Nombre == artista.Nombre && a.NombreArtista == artista.NombreArtista))
                    {
                        DisplayAlert("Peticion atendida", "Datos guardados con exito, datos:" + artista.Nombre + " " + artista.NombreArtista, "Aceptar");
                        Navigation.PushAsync(new PaginaInicio());
                    }
                    else
                    {
                        DisplayAlert("Peticion no atendida", "Ocurrio un error compruebelo porfavor", "Aceptar");
                        txtNombre.Text = string.Empty;
                        txtNombreArtista.Text = string.Empty;
                    }
                }
            }
        }
    }
}