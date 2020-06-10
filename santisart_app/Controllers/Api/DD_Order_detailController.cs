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
using AutoMapper;
using AutoMapper.QueryableExtensions;
using santisart_app.App_Start;
using santisart_app.Dto;
using santisart_app.Models;

namespace santisart_app.Controllers.Api
{
    public class DD_Order_detailController : ApiController
    {
        private santisartEntities3 db = new santisartEntities3();

        // GET: api/DD_Order_detail
        public IQueryable<OrderDetailDto> GetDD_Order_detail()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });

            var mapper = config.CreateMapper();
            return db.DD_Order_detail.ProjectTo<OrderDetailDto>(config).AsQueryable();
        }

        
        // GET: api/DD_Order_detail/5
        [ResponseType(typeof(DD_Order_detail))]
        public IHttpActionResult GetDD_Order_detail(int id)
        {
            DD_Order_detail dD_Order_detail = db.DD_Order_detail.Find(id);
            if (dD_Order_detail == null)
            {
                return NotFound();
            }

            return Ok(dD_Order_detail);
        }

        // PUT: api/DD_Order_detail/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDD_Order_detail(int id, DD_Order_detail dD_Order_detail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dD_Order_detail.index)
            {
                return BadRequest();
            }

            db.Entry(dD_Order_detail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DD_Order_detailExists(id))
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

        // POST: api/DD_Order_detail
        [ResponseType(typeof(DD_Order_detail))]
        public IHttpActionResult PostDD_Order_detail(DD_Order_detail dD_Order_detail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DD_Order_detail.Add(dD_Order_detail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dD_Order_detail.index }, dD_Order_detail);
        }

        // DELETE: api/DD_Order_detail/5
        [ResponseType(typeof(DD_Order_detail))]
        public IHttpActionResult DeleteDD_Order_detail(int id)
        {
            DD_Order_detail dD_Order_detail = db.DD_Order_detail.Find(id);
            if (dD_Order_detail == null)
            {
                return NotFound();
            }

            db.DD_Order_detail.Remove(dD_Order_detail);
            db.SaveChanges();

            return Ok(dD_Order_detail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DD_Order_detailExists(int id)
        {
            return db.DD_Order_detail.Count(e => e.index == id) > 0;
        }
    }
}