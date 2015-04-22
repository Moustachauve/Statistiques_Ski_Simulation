using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace statistiques_ski.DAL
{
	public class UnitOfWork : IUnitOfWork
	{

		public int CurrentUserID { get { return 1; } }

		private Statistiques_SkiContext context = new Statistiques_SkiContext();

        private CentreDeSkiRepository centreDeSkiRepository;
        public CentreDeSkiRepository CentreDeSkiRepository
        {
            get
            {
                if (this.centreDeSkiRepository == null)
                {
                    this.centreDeSkiRepository = new CentreDeSkiRepository(context);
                }
                return this.centreDeSkiRepository;
            }
        }

        private SkieurRepository skieurRepository;
        public SkieurRepository SkieurRepository
        {
            get
            {
                if (this.skieurRepository == null)
                {
                    this.skieurRepository = new SkieurRepository(context);
                }
                return this.skieurRepository;
            }
        }

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
		private SortieRepository sortieRepository;
        
		public SortieRepository SortieRepository
		{
			get
			{
				if (this.sortieRepository == null)
					this.sortieRepository = new SortieRepository(context);
				return this.sortieRepository;
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