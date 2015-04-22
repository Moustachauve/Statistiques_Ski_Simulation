using statistiques_ski.DAL;
using statistiques_ski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace statistiques_ski.Controllers
{
    public class StatistiquesController : Controller
    {
		private UnitOfWork uow = new UnitOfWork();
        // GET: Statistique
        public ActionResult Index()
        {
			ViewBag.sorties = uow.SortieRepository.Get();
			ViewBag.centreDeSkis = uow.CentreDeSkiRepository.Get();
			ViewBag.saisons = uow.SaisonRepository.Get();

            return View();
        }
    }
}