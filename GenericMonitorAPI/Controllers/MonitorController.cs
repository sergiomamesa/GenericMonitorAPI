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
using GenericMonitorAPI.API.Filters;

namespace GenericMonitorAPI.Controllers
{

    public class MonitorController : ApiController
    {
        private GenericMonitorAPIContext db = new GenericMonitorAPIContext();

        protected MonitorController()
        {
        }

        [AllowAnonymous]
        public IQueryable<Monitorization> GetMonitorizations()
        {
            return db.Monitorizations;
        }

        [Authorize(Roles = "Writer")]
        [SimpleAuthenticationFilter]
        [ResponseType(typeof(Monitorization))]
        public IHttpActionResult PostMonitorization(Monitorization monitorization)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Monitorizations.Add(monitorization);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = monitorization.Key }, monitorization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}