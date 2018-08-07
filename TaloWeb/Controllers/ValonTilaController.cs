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
    public class ValonTilaController : Controller
    {
        private TaloEntities db = new TaloEntities();

        // GET: ValonTila
        public ActionResult Index()
        {
            var valonTila = db.ValonTila.Include(v => v.Valot);
            return View(valonTila.ToList());
        }

        // GET: ValonTila/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValonTila valonTila = db.ValonTila.Find(id);
            if (valonTila == null)
            {
                return HttpNotFound();
            }
            return View(valonTila);
        }

        // GET: ValonTila/Create
        public ActionResult Create()
        {
            ViewBag.ValoID = new SelectList(db.Valot, "ValoID", "ValonSijainti");
            return View();
        }

        // POST: ValonTila/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ValonTilaID,ValoID,valonTila1,ValonMaara,PVM")] ValonTila valonTila)
        {
            if (ModelState.IsValid)
            {
                db.ValonTila.Add(valonTila);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ValoID = new SelectList(db.Valot, "ValoID", "ValonSijainti", valonTila.ValoID);
            return View(valonTila);
        }

        // GET: ValonTila/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValonTila valonTila = db.ValonTila.Find(id);
            if (valonTila == null)
            {
                return HttpNotFound();
            }
            ViewBag.ValoID = new SelectList(db.Valot, "ValoID", "ValonSijainti", valonTila.ValoID);
            return View(valonTila);
        }

        // POST: ValonTila/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ValonTilaID,ValoID,valonTila1,ValonMaara,PVM")] ValonTila valonTila)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valonTila).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ValoID = new SelectList(db.Valot, "ValoID", "ValonSijainti", valonTila.ValoID);
            return View(valonTila);
        }

        // GET: ValonTila/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValonTila valonTila = db.ValonTila.Find(id);
            if (valonTila == null)
            {
                return HttpNotFound();
            }
            return View(valonTila);
        }

        // POST: ValonTila/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ValonTila valonTila = db.ValonTila.Find(id);
            db.ValonTila.Remove(valonTila);
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
