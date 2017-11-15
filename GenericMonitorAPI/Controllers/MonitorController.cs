using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using GenericMonitorAPI.Context;
using GenericMonitorAPI.API.Filters;
using GenericMonitorAPI.Models;

namespace GenericMonitorAPI.Controllers
{

    public class MonitorController : ApiController
    {
        private readonly GenericMonitorAPIContext db = new GenericMonitorAPIContext();

        protected MonitorController()
        {

        }

        [AllowAnonymous]
        public IQueryable<Monitorization> GetMonitorizations()
        {
            return db.Monitorizations;
        }

        //[Authorize(Roles = "Writer")]
        [SimpleAuthenticationFilter]
        [ResponseType(typeof(Monitorization))]
        public IHttpActionResult PostMonitorization(Monitorization monitorization)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Monitorizations.Add(monitorization);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = monitorization.Id }, monitorization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}