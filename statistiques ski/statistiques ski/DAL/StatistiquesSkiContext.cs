using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using statistiques_ski.Models;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace statistiques_ski.DAL
{
    public class Statistiques_SkiContext : DbContext
    {
        public Statistiques_SkiContext() : base() {}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Entity<CentreDeSki>().HasMany(e => e.Sorties).WithRequired(e => e.CentreDeSki).WillCascadeOnDelete(true);
			modelBuilder.Entity<Saison>().HasMany(e => e.Sorties).WithRequired(e => e.Saison).WillCascadeOnDelete(false);
		}


		public virtual DbSet<CentreDeSki> CentreDeSkis { get; set; }
		public virtual DbSet<Region> Regions { get; set; }
		public virtual DbSet<Saison> Saisons { get; set; }
		public virtual DbSet<Skieur> Skieurs { get; set; }
		public virtual DbSet<Sortie> Sorties { get; set; }
    }
}