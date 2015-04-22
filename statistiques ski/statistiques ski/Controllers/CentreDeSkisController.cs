using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using statistiques_ski.DAL;
using statistiques_ski.Models;

namespace statistiques_ski.Controllers
{
    public class CentreDeSkisController : Controller
    {
        //private Statistiques_SkiContext db = new Statistiques_SkiContext();
		private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: CentreDeSkis
        public ActionResult Index()
        {
			var centreDeSkis = unitOfWork.CentreDeSkiRepository.GetForUser(unitOfWork.CurrentUserID);//db.CentreDeSkis.Include(c => c.Region).Include(c => c.Skieur);
            return View(centreDeSkis.ToList());
        }

        // GET: CentreDeSkis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			CentreDeSki centreDeSki = unitOfWork.CentreDeSkiRepository.GetByID((int)id);
            if (centreDeSki == null)
            {
                return HttpNotFound();
            }
            return View(centreDeSki);
        }

        // GET: CentreDeSkis/Create
        public ActionResult Create()
        {
			ViewBag.RegionID = new SelectList(unitOfWork.RegionRepository.Get(), "RegionID", "NomRegion");
			ViewBag.SkieurID = new SelectList(unitOfWork.SkieurRepository.Get(), "SkieurID", "Nom");
            return View();
        }

        // POST: CentreDeSkis/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CentreDeSkiID,Nom,Adresse,NbPistes,Altitude,RegionID,SkieurID")] CentreDeSki centreDeSki)
        {
            if (ModelState.IsValid)
            {
				unitOfWork.CentreDeSkiRepository.Insert(centreDeSki);
				unitOfWork.Save();
                return RedirectToAction("Index");
            }

			ViewBag.RegionID = new SelectList(unitOfWork.RegionRepository.Get(), "RegionID", "NomRegion", centreDeSki.RegionID);
			ViewBag.SkieurID = new SelectList(unitOfWork.SkieurRepository.Get(), "SkieurID", "Nom", centreDeSki.Region.SkieurID);
            return View(centreDeSki);
        }

        // GET: CentreDeSkis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			CentreDeSki centreDeSki = unitOfWork.CentreDeSkiRepository.GetByID((int)id);
            if (centreDeSki == null)
            {
                return HttpNotFound();
            }
			ViewBag.RegionID = new SelectList(unitOfWork.RegionRepository.Get(), "RegionID", "NomRegion", centreDeSki.RegionID);
			ViewBag.SkieurID = new SelectList(unitOfWork.SkieurRepository.Get(), "SkieurID", "Nom", centreDeSki.Region.SkieurID);
            return View(centreDeSki);
        }

        // POST: CentreDeSkis/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CentreDeSkiID,Nom,Adresse,NbPistes,Altitude,RegionID,SkieurID")] CentreDeSki centreDeSki)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(centreDeSki).State = EntityState.Modified;
				unitOfWork.CentreDeSkiRepository.Update(centreDeSki);
				unitOfWork.Save();
                return RedirectToAction("Index");
            }
			ViewBag.RegionID = new SelectList(unitOfWork.RegionRepository.Get(), "RegionID", "NomRegion", centreDeSki.RegionID);
			ViewBag.SkieurID = new SelectList(unitOfWork.SkieurRepository.Get(), "SkieurID", "Nom", centreDeSki.Region.SkieurID);
            return View(centreDeSki);
        }

        // GET: CentreDeSkis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			CentreDeSki centreDeSki = unitOfWork.CentreDeSkiRepository.GetForUserByID((int)id, unitOfWork.CurrentUserID);
            if (centreDeSki == null)
            {
                return HttpNotFound();
            }
            return View(centreDeSki);
        }

        // POST: CentreDeSkis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			CentreDeSki centreDeSki = unitOfWork.CentreDeSkiRepository.GetForUserByID((int)id, unitOfWork.CurrentUserID);
			unitOfWork.CentreDeSkiRepository.Delete(centreDeSki);
			unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
