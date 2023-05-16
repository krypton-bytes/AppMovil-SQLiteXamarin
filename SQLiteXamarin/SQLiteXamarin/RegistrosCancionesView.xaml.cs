using Microsoft.EntityFrameworkCore;
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
    public partial class RegistrosCancionesView : ContentPage
    {
        ModeloBD bd = new ModeloBD();
        public RegistrosCancionesView()
        {
            InitializeComponent();
            ObtenerRegistros();
        }
        private void ObtenerRegistros()
        {
            List<CancionModel> registros = bd.Canciones.Include(c => c.Artista).Include(c => c.Discografia).ToList();
            listView.ItemsSource = registros;
        }
    }
}