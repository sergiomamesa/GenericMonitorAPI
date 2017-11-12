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
using GenericMonitorAPI.Context;

namespace GenericMonitorAPI.Controllers
{
    public class MonitorController : ApiController
    {
        private GenericMonitorAPIContext db = new GenericMonitorAPIContext();

        protected MonitorController()
        {
        }

        // GET: api/Monitor
        public IQueryable<Monitorization> GetMonitorizations()
        {
            return db.Monitorizations;
        }

        // GET: api/Monitor/5
        [ResponseType(typeof(Monitorization))]
        public IHttpActionResult GetMonitorization(int id)
        {
            Monitorization monitorization = db.Monitorizations.Find(id);
            if (monitorization == null)
                return NotFound();

            return Ok(monitorization);
        }

        // PUT: api/Monitor/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMonitorization(int id, Monitorization monitorization)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != monitorization.Key)
                return BadRequest();

            db.Entry(monitorization).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonitorizationExists(id))
                    return NotFound();

                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Monitor
        [ResponseType(typeof(Monitorization))]
        public IHttpActionResult PostMonitorization(Monitorization monitorization)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Monitorizations.Add(monitorization);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = monitorization.Key }, monitorization);
        }

        // DELETE: api/Monitor/5
        [ResponseType(typeof(Monitorization))]
        public IHttpActionResult DeleteMonitorization(int id)
        {
            Monitorization monitorization = db.Monitorizations.Find(id);
            if (monitorization == null)
                return NotFound();

            db.Monitorizations.Remove(monitorization);
            db.SaveChanges();

            return Ok(monitorization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool MonitorizationExists(int id)
        {
            return db.Monitorizations.Count(e => e.Key == id) > 0;
        }
    }
}