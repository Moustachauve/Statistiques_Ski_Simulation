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
    public class SortiesController : Controller
    {
        //private Statistiques_SkiContext db = new Statistiques_SkiContext();
        private UnitOfWork uow = new UnitOfWork();

        // GET: Sorties
        //public ActionResult Index()
        //{
        //    var sorties = uow.SortieRepository.Get();
        //    return View(sorties.ToList());
        //}

        [HttpGet]
        public ActionResult Index(string orderBy, bool? asc)
        {
            IEnumerable<Sortie> sorties = null;

            ViewBag.isAsc = asc;
            ViewBag.orderBy = orderBy;

            if (orderBy == null)
                sorties = uow.SortieRepository.Get();
            else
                sorties = uow.SortieRepository.GetOrderBy(orderBy, asc != null ? (bool)asc : false);

            return View(sorties.ToList());
        }

        // GET: Sorties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sortie sortie = uow.SortieRepository.GetByID(id);
            if (sortie == null)
            {
                return HttpNotFound();
            }
            return View(sortie);
        }

        // GET: Sorties/Create
        public ActionResult Create()
        {
            ViewBag.CentreDeSkiID = new SelectList(uow.CentreDeSkiRepository.Get(), "CentreDeSkiID", "Nom");
            ViewBag.SaisonID = new SelectList(uow.SaisonRepository.Get(), "SaisonID", "AnneeDebutSaison");
            //ViewBag.SkieurID = new SelectList(uow.SkieurRepository.Get(), "SkieurID", "Nom");
            return View();
        }

        // POST: Sorties/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SortieID,NbDescente,NbPiedVert,Date,CentreDeSkiID,SaisonID")] Sortie sortie)
        {
            if (ModelState.IsValid)
            {
                uow.SortieRepository.Insert(sortie);
                sortie.Saison.SkieurID = uow.CurrentUserID;
                uow.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CentreDeSkiID = new SelectList(uow.CentreDeSkiRepository.Get(), "CentreDeSkiID", "Nom", sortie.CentreDeSkiID);
            ViewBag.SaisonID = new SelectList(uow.SaisonRepository.Get(), "SaisonID", "SaisonID", sortie.SaisonID);
            ViewBag.SkieurID = new SelectList(uow.SkieurRepository.Get(), "SkieurID", "Nom", uow.CurrentUserID);
            return View(sortie);
        }

        // GET: Sorties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sortie sortie = uow.SortieRepository.GetByID(id);
            if (sortie == null)
            {
                return HttpNotFound();
            }
            ViewBag.CentreDeSkiID = new SelectList(uow.CentreDeSkiRepository.Get(), "CentreDeSkiID", "Nom", sortie.CentreDeSkiID);
            ViewBag.SaisonID = new SelectList(uow.SaisonRepository.Get(), "SaisonID", "SaisonID", sortie.SaisonID);
            ViewBag.SkieurID = new SelectList(uow.SkieurRepository.Get(), "SkieurID", "Nom", sortie.Saison.SkieurID);
            return View(sortie);
        }

        // POST: Sorties/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SortieID,NbDescente,NbPiedVert,Date,CentreDeSkiID,SkieurID,SaisonID")] Sortie sortie)
        {
            if (ModelState.IsValid)
            {
                uow.SortieRepository.Update(sortie);
                uow.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CentreDeSkiID = new SelectList(uow.CentreDeSkiRepository.Get(), "CentreDeSkiID", "Nom", sortie.CentreDeSkiID);
            ViewBag.SaisonID = new SelectList(uow.CentreDeSkiRepository.Get(), "SaisonID", "SaisonID", sortie.SaisonID);
            ViewBag.SkieurID = new SelectList(uow.CentreDeSkiRepository.Get(), "SkieurID", "Nom", sortie.Saison.SkieurID);
            return View(sortie);
        }

        // GET: Sorties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sortie sortie = uow.SortieRepository.GetByID(id);
            if (sortie == null)
            {
                return HttpNotFound();
            }
            return View(sortie);
        }

        // POST: Sorties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sortie sortie = uow.SortieRepository.GetByID(id);
            uow.SortieRepository.Delete(sortie);
            uow.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uow.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
