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
    public partial class RegistroArtistaView : ContentPage
    {
        ModeloBD bd = new ModeloBD();
        public RegistroArtistaView()
        {
            InitializeComponent();
            ObtenerRegistros();
        }
        private void ObtenerRegistros()
        {
            List<ArtistaModel> registros = bd.Artistas.ToList();
            listView.ItemsSource = registros;
        }
    }
}