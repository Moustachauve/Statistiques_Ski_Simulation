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
    public class RegionsController : Controller
    {
        UnitOfWork uow = new UnitOfWork();

        // GET: Regions
        public ActionResult Index(bool? isEmpty)
        {
            var regions = uow.RegionRepository.GetForSkieur(uow.CurrentUserID);
            return View(regions.ToList());
        }

        // GET: Regions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = uow.RegionRepository.GetForSkieurByID((int)id, uow.CurrentUserID);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // GET: Regions/Create
        public ActionResult Create()
        {
            //ViewBag.SkieurID = new SelectList(uow.SkieurRepository.Get(), "SkieurID", "Nom");
            return View();
        }

        // POST: Regions/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegionID,NomRegion")] Region region)
        {
            if (ModelState.IsValid)
            {
                uow.RegionRepository.Insert(region);
                region.SkieurID = uow.CurrentUserID;
                uow.Save();
                return RedirectToAction("Index");
            }

            ViewBag.SkieurID = new SelectList(uow.SkieurRepository.Get(), "SkieurID", "Nom", uow.CurrentUserID);
            return View(region);
        }

        // GET: Regions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = uow.RegionRepository.GetForSkieurByID((int)id, uow.CurrentUserID);
            if (region == null)
            {
                return HttpNotFound();
            }
            //ViewBag.SkieurID = new SelectList(uow.SkieurRepository.Get(), "SkieurID", "Nom", region.SkieurID);
            return View(region);
        }

        // POST: Regions/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegionID,NomRegion")] Region region)
        {
            if (ModelState.IsValid)
            {
                uow.RegionRepository.Update(region);
                region.SkieurID = uow.CurrentUserID;
                uow.Save();
                return RedirectToAction("Index");
            }
            ViewBag.SkieurID = new SelectList(uow.SkieurRepository.Get(), "SkieurID", "Nom", uow.CurrentUserID);
            return View(region);
        }

        // GET: Regions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = uow.RegionRepository.GetForSkieurByID((int)id, uow.CurrentUserID);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // POST: Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Region region = uow.RegionRepository.GetForSkieurByID((int)id, uow.CurrentUserID);
            uow.RegionRepository.Delete(region);
            uow.Save();
            return RedirectToAction("Index");
        }
    }
}
