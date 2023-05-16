using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteXamarin.Modelo
{
    internal class CancionModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public int ArtistaID { get; set; }
        public virtual ArtistaModel Artista { get; set; }

        public int DiscografiaID { get; set; }
        public virtual DiscografiaModel Discografia { get; set;}
    }
}
