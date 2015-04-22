using statistiques_ski.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace statistiques_ski.Controllers
{
    public class StatistiqueController : Controller
    {
		private UnitOfWork uow = new UnitOfWork();
        // GET: Statistique
        public ActionResult Index()
        {
			var sorties = uow.SortieRepository.Get();
			var centreDeSkis = uow.CentreDeSkiRepository.Get();
			var saisons = uow.SaisonRepository.Get();
            return View();
        }
    }
}