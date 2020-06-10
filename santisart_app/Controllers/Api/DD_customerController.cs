using System;
using System.Collections.Generic;
using System.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using santisart_app.App_Start;
using santisart_app.Dto;
using santisart_app.Models;
using System.Web.Http.Description;

namespace santisart_app.Controllers.Api
{
    public class DD_customerController : ApiController
    {
        private santisartEntities3 db = new santisartEntities3();

        // GET: api/DD_customer
        public IQueryable<CustomerDto> GetDD_customer()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });

            var mapper = config.CreateMapper();
            return db.DD_customer.ProjectTo<CustomerDto>(config).AsQueryable();
        }

        // GET: api/DD_customer/5
        [ResponseType(typeof(CustomerDto))]
        public IHttpActionResult GetDD_customer(int id)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });

            var mapper = config.CreateMapper();
            DD_customer dD_customer = db.DD_customer.Find(id);
            if (dD_customer == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<DD_customer,CustomerDto>( dD_customer));
        }

        // PUT: api/DD_customer/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDD_customer(int id, DD_customer dD_customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dD_customer.index)
            {
                return BadRequest();
            }

            db.Entry(dD_customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DD_customerExists(id))
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

        // POST: api/DD_customer
        [HttpPost]
        public IHttpActionResult PostDD_customer( CustomerDto customerDto)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });

            var mapper = config.CreateMapper();
            var customer = mapper.Map<CustomerDto, DD_customer>(customerDto);
            db.DD_customer.Add(customer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customer.index }, customer);
        }

        // DELETE: api/DD_customer/5
        [ResponseType(typeof(DD_customer))]
        public IHttpActionResult DeleteDD_customer(int id)
        {
            DD_customer dD_customer = db.DD_customer.Find(id);
            if (dD_customer == null)
            {
                return NotFound();
            }

            db.DD_customer.Remove(dD_customer);
            db.SaveChanges();

            return Ok(dD_customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DD_customerExists(int id)
        {
            return db.DD_customer.Count(e => e.index == id) > 0;
        }
    }
}