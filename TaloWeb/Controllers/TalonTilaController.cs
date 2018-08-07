using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaloWeb;
using TaloWeb.Utilities;
using Newtonsoft.Json;
using TaloWeb.Models;


namespace TaloWeb.Controllers
{
    public class TalonTilaController : Controller
    {
        private TaloEntities db = new TaloEntities();

        // GET: TalonTila
        public ActionResult Index()
        {
            var talonTila = db.TalonTila.Include(t => t.Talot);
            return View(talonTila.ToList());
        }

        // GET: TalonTila/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TalonTila talonTila = db.TalonTila.Find(id);
            if (talonTila == null)
            {
                return HttpNotFound();
            }
            return View(talonTila);
        }

        // GET: TalonTila/Create
        public ActionResult Create()
        {
            TaloEntities db = new TaloEntities();
            TalonTila model = new TalonTila();

            ViewBag.TaloID = new SelectList(db.Talot, "TaloID", "TalonSijainti");
            return View(model);
        }
        
        /*
        
        [HttpPost]
        public JsonResult AsetaTalonLampotila()

        {
            string json = Request.InputStream.ReadToEnd();
            TalonTilaModel inputData = JsonConvert.DeserializeObject<TalonTilaModel>(json);

            bool success = false;
            string error = "";

            TaloEntities entities = new TaloEntities();

            try
            {
                
                var model = (from t in entities.Talot
                          where t.TaloId == id
                          select new 
                          {
                          TaloID = t.TaloId
                          })FirstOrDefault();

                string TalonNykyLampotila = (from t in entities.TalonTila
                              where t.code == inputData.TalonNykyLampotila
                              select t.TalonNykyLampotila.FirstOrDefault);

                string TalonTavoiteLampotila = (from t in entities.TalonTila
                                                where t.Code == inputData.TalonTavoiteLampotila
                                                select t.TalonTavoiteLampotila.FirstOrDefault);

                int talonTilaId = (from t in entities.TalonTila
                                   where t.TalonTilaId == id
                                   select t.talontilaId.FirstOrDefault);

                if((taloId > 0) && (talonTilaId > 0))// (TalonNykyLampotila > 0 ) && (TalonTavoiteLampotila > 0) )
                {
                    TalonTila newEntry = new TalonTila();
                   
                    newEntry.TaloID = taloId;
                    newEntry.TalonTilaID = talonTilaId;
                   // newEntry.PVM = datetime;

                    entities.TalonTila.Add(newEntry);
                    entities.SaveChanges();

                    success = true;
                }
            }
            catch (Exception ex )
            {
                error = ex.GetType().Name + ":" + ex.Message;
            }
            finally
            {
                entities.Dispose();
            }
            var result = new { success = success, error = error };
            return Json(result);
        }
      
    */
        // POST: TalonTila/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TalonTilaModel model )
        {
            TalonTila tila = db.TalonTila.Find(model.TalonTilaID);
            tila.TalonTilaID = model.TalonTilaID;
            tila.TalonTavoiteLampotila = model.TalonTavoiteLampotila;
            tila.TalonNykyLampotila = model.TalonNykyLampotila;
            tila.PVM = DateTime.Now;
            //tila. = model.Talot?.TalonSijainti;
            tila.TaloID = model.Talot?.TaloID;
           // db.TalonTila.Add(tila);
            try
            {
                db.SaveChanges();
            }

            catch (Exception  ex)
            {
               
            }
            ///*
            //if (ModelState.IsValid)
            //{
            //    db.TalonTila.Add(talonTila);
            //    db.SaveChanges();*/
            //    return RedirectToAction("Index");
            //}

          

            ViewBag.TaloID = new SelectList(db.Talot, "TaloID", "TalonSijainti", tila.TaloID);
            // return View(talonTila);

            return RedirectToAction("Index");
        }

        // GET: TalonTila/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TalonTila talonTila = db.TalonTila.Find(id);
            if (talonTila == null)
            {
                return HttpNotFound();
            }
            ViewBag.TaloID = new SelectList(db.Talot, "TaloID", "TalonSijainti", talonTila.TaloID);
            return View(talonTila);
        }

        // POST: TalonTila/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TalonTilaID,TaloID,TalonTavoiteLampotila,TalonNykyLampotila,PVM")] TalonTila talonTila)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talonTila).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TaloID = new SelectList(db.Talot, "TaloID", "TalonSijainti", talonTila.TaloID);
            return View(talonTila);
        }

        // GET: TalonTila/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TalonTila talonTila = db.TalonTila.Find(id);
            if (talonTila == null)
            {
                return HttpNotFound();
            }
            return View(talonTila);
        }

        // POST: TalonTila/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TalonTila talonTila = db.TalonTila.Find(id);
            db.TalonTila.Remove(talonTila);
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
