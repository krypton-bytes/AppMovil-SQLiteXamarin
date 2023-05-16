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
    public partial class RegistrosDiscografiaView : ContentPage
    {
        ModeloBD bd = new ModeloBD();
        public RegistrosDiscografiaView()
        {
            InitializeComponent();
            ObtenerRegistros();
        }
        private void ObtenerRegistros()
        {
            List<DiscografiaModel> registros = bd.Discografia.ToList();
            listView.ItemsSource = registros;
        }
    }
}