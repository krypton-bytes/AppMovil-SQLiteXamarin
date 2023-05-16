using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace SQLiteXamarin.Modelo
{
    class ModeloBD : DbContext
    {
        public ModeloBD()
        {
            SQLitePCL.Batteries_V2.Init();

            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "bdRecorridos2.db3");

            optionsBuilder
                .UseSqlite($"Filename={dbPath}");
        }
        public virtual DbSet<CancionModel> Canciones { get; set; }
        public virtual DbSet<DiscografiaModel> Discografia { get; set; }
        public virtual DbSet<ArtistaModel> Artistas { get; set; }
    }
}
