using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace statistiques_ski.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private Statistiques_SkiContext context = new Statistiques_SkiContext();

        private RegionRepository regionrepository;
        public RegionRepository RegionRepository
        {
            get
            {
                if (this.regionrepository == null)
                {
                    this.regionrepository = new RegionRepository(context);
                }
                return regionrepository;
            }
        }

        private SaisonRepository saisonrepository;
        public SaisonRepository SaisonRepository
        {
            get
            {
                if (this.saisonrepository == null)
                {
                    this.saisonrepository = new SaisonRepository(context);
                }
                return saisonrepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}