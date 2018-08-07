using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaloWeb;

namespace TaloWeb.Controllers
{
    public class SaunanTilaController : Controller
    {
        private TaloEntities db = new TaloEntities();

        // GET: SaunanTila
        public ActionResult Index()
        {
            var saunanTila = db.SaunanTila.Include(s => s.Saunat);
            return View(saunanTila.ToList());
        }

        // GET: SaunanTila/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaunanTila saunanTila = db.SaunanTila.Find(id);
            if (saunanTila == null)
            {
                return HttpNotFound();
            }
            return View(saunanTila);
        }

        // GET: SaunanTila/Create
        public ActionResult Create()
        {
            ViewBag.SaunaID = new SelectList(db.Saunat, "SaunaID", "SaunanSijainti");
            return View();
        }

        // POST: SaunanTila/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaunanTilaID,SaunaID,SaunanTila1,SaunanLampotila,PVM")] SaunanTila saunanTila)
        {
            if (ModelState.IsValid)
            {
                db.SaunanTila.Add(saunanTila);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SaunaID = new SelectList(db.Saunat, "SaunaID", "SaunanSijainti", saunanTila.SaunaID);
            return View(saunanTila);
        }

        // GET: SaunanTila/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaunanTila saunanTila = db.SaunanTila.Find(id);
            if (saunanTila == null)
            {
                return HttpNotFound();
            }
            ViewBag.SaunaID = new SelectList(db.Saunat, "SaunaID", "SaunanSijainti", saunanTila.SaunaID);
            return View(saunanTila);
        }

        // POST: SaunanTila/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaunanTilaID,SaunaID,SaunanTila1,SaunanLampotila,PVM")] SaunanTila saunanTila)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saunanTila).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SaunaID = new SelectList(db.Saunat, "SaunaID", "SaunanSijainti", saunanTila.SaunaID);
            return View(saunanTila);
        }

        // GET: SaunanTila/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaunanTila saunanTila = db.SaunanTila.Find(id);
            if (saunanTila == null)
            {
                return HttpNotFound();
            }
            return View(saunanTila);
        }

        // POST: SaunanTila/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SaunanTila saunanTila = db.SaunanTila.Find(id);
            db.SaunanTila.Remove(saunanTila);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
