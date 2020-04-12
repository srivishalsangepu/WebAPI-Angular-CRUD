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
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class userscrudsController : ApiController
    {
        private WebApiDbEntities db = new WebApiDbEntities();

        // GET: api/userscruds
        public IQueryable<userscrud> Getuserscruds()
        {
            return db.userscruds;
        }

        // GET: api/userscruds/5
        [ResponseType(typeof(userscrud))]
        public IHttpActionResult Getuserscrud(int id)
        {
            userscrud userscrud = db.userscruds.Find(id);
            if (userscrud == null)
            {
                return NotFound();
            }

            return Ok(userscrud);
        }

        // PUT: api/userscruds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putuserscrud(int id, userscrud userscrud)
        {
            if (id != userscrud.Id)
            {
                return BadRequest();
            }

            db.Entry(userscrud).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userscrudExists(id))
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

        // POST: api/userscruds
        [ResponseType(typeof(userscrud))]
        public IHttpActionResult Postuserscrud(userscrud userscrud)
        {
            db.userscruds.Add(userscrud);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userscrud.Id }, userscrud);
        }

        // DELETE: api/userscruds/5
        [ResponseType(typeof(userscrud))]
        public IHttpActionResult Deleteuserscrud(int id)
        {
            userscrud userscrud = db.userscruds.Find(id);
            if (userscrud == null)
            {
                return NotFound();
            }

            db.userscruds.Remove(userscrud);
            db.SaveChanges();

            return Ok(userscrud);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool userscrudExists(int id)
        {
            return db.userscruds.Count(e => e.Id == id) > 0;
        }
    }
}