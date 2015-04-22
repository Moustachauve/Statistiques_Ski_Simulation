using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace statistiques_ski.DAL
{
	public class UnitOfWork : IUnitOfWork
	{
		private Statistiques_SkiContext context = new Statistiques_SkiContext();

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