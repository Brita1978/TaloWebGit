using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TaloWeb;

namespace TaloWeb.Controllers
{
    public class TalonTilasController : ApiController
    {
        private TaloEntities db = new TaloEntities();

        // GET: api/TalonTilas
        public IQueryable<TalonTila> GetTalonTila()
        {
            return db.TalonTila;
        }

        // GET: api/TalonTilas/5
        [ResponseType(typeof(TalonTila))]
        public IHttpActionResult GetTalonTila(int id)
        {
            TalonTila talonTila = db.TalonTila.Find(id);
            if (talonTila == null)
            {
                return NotFound();
            }

            return Ok(talonTila);
        }

        // PUT: api/TalonTilas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTalonTila(int id, TalonTila talonTila)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != talonTila.TalonTilaID)
            {
                return BadRequest();
            }

            db.Entry(talonTila).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TalonTilaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TalonTilas
        [ResponseType(typeof(TalonTila))]
        public IHttpActionResult PostTalonTila(TalonTila talonTila)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TalonTila.Add(talonTila);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = talonTila.TalonTilaID }, talonTila);
        }

        // DELETE: api/TalonTilas/5
        [ResponseType(typeof(TalonTila))]
        public IHttpActionResult DeleteTalonTila(int id)
        {
            TalonTila talonTila = db.TalonTila.Find(id);
            if (talonTila == null)
            {
                return NotFound();
            }

            db.TalonTila.Remove(talonTila);
            db.SaveChanges();

            return Ok(talonTila);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TalonTilaExists(int id)
        {
            return db.TalonTila.Count(e => e.TalonTilaID == id) > 0;
        }
    }
}