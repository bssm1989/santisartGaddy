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
using santisart_app.Models;

namespace santisart_app.Controllers.Api
{
    public class DD_OrdersController : ApiController
    {
        private santisartEntities3 db = new santisartEntities3();

        // GET: api/DD_Orders
        public IQueryable<DD_Orders> GetDD_Orders()
        {
            return db.DD_Orders;
        }

        // GET: api/DD_Orders/5
        [ResponseType(typeof(DD_Orders))]
        public IHttpActionResult GetDD_Orders(int id)
        {
            DD_Orders dD_Orders = db.DD_Orders.Find(id);
            if (dD_Orders == null)
            {
                return NotFound();
            }

            return Ok(dD_Orders);
        }

        // PUT: api/DD_Orders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDD_Orders(int id, DD_Orders dD_Orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dD_Orders.index)
            {
                return BadRequest();
            }

            db.Entry(dD_Orders).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DD_OrdersExists(id))
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

        // POST: api/DD_Orders
        [ResponseType(typeof(DD_Orders))]
        public IHttpActionResult PostDD_Orders(DD_Orders dD_Orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DD_Orders.Add(dD_Orders);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dD_Orders.index }, dD_Orders);
        }

        // DELETE: api/DD_Orders/5
        [ResponseType(typeof(DD_Orders))]
        public IHttpActionResult DeleteDD_Orders(int id)
        {
            DD_Orders dD_Orders = db.DD_Orders.Find(id);
            if (dD_Orders == null)
            {
                return NotFound();
            }

            db.DD_Orders.Remove(dD_Orders);
            db.SaveChanges();

            return Ok(dD_Orders);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DD_OrdersExists(int id)
        {
            return db.DD_Orders.Count(e => e.index == id) > 0;
        }
    }
}