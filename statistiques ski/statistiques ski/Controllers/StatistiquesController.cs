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

		public ActionResult Index(FormCollection form)
		{
			if (form != null)
			{
				var filterBy = form.GetValue("filterBy");

				if (filterBy != null)
				{
					int temp = (int)filterBy.ConvertTo(typeof(int));
					if (temp != 0)
					{
						ViewBag.centreDeSkis = uow.CentreDeSkiRepository.Get(filter: x => x.RegionID == temp && x.Region.SkieurID == uow.CurrentUserID);
						ViewBag.RegionID = temp;
					}
					else
					{
						ViewBag.centreDeSkis = uow.CentreDeSkiRepository.GetForSkieur(uow.CurrentUserID);
						ViewBag.RegionID = temp;
					}
				}
				else
				{
					ViewBag.centreDeSkis = uow.CentreDeSkiRepository.GetForSkieur(uow.CurrentUserID);
					ViewBag.RegionID = 0;
				}
			}
			else
			{
				ViewBag.centreDeSkis = uow.CentreDeSkiRepository.GetForSkieur(uow.CurrentUserID);
				ViewBag.RegionID = 0;
			}

			ViewBag.sorties = uow.SortieRepository.GetForSkieur(uow.CurrentUserID);
			ViewBag.saisons = uow.SaisonRepository.GetForSkieur(uow.CurrentUserID);
			ViewBag.regions = uow.RegionRepository.GetForSkieur(uow.CurrentUserID);

			return View();
		}
	}
}