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
namespace santisart_app.Controllers.Api
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using santisart_app.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<DD_Orders>("DD_Orders2");
    builder.EntitySet<DD_customer>("DD_customer"); 
    builder.EntitySet<DD_Order_detail>("DD_Order_detail"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class DD_Orders2Controller : ODataController
    {
        private santisartEntities3 db = new santisartEntities3();

        // GET: odata/DD_Orders2
      
        [EnableQuery]
        public IQueryable<DD_Orders> GetDD_Orders2()
        {
            //var config = new MapperConfiguration(cfg => {
            //    cfg.AddProfile<MappingProfile>();
            //});

            //var mapper = config.CreateMapper();
            //Mapper.Map<DD_Orders, OrdersDto>();
            //db.DD_Orders.Where(x => x.Order_status != "Canceled").ProjectTo<OrdersDto>(config).AsQueryable()
           

            return db.DD_Orders.ToList().AsQueryable();
        }

        // GET: odata/DD_Orders2(5)
        [EnableQuery]
        public SingleResult<DD_Orders> GetDD_Orders([FromODataUri] int key)
        {
            return SingleResult.Create(db.DD_Orders.Where(dD_Orders => dD_Orders.index == key));
        }

        // PUT: odata/DD_Orders2(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<DD_Orders> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DD_Orders dD_Orders = db.DD_Orders.Find(key);
            if (dD_Orders == null)
            {
                return NotFound();
            }

            patch.Put(dD_Orders);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DD_OrdersExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dD_Orders);
        }

        // POST: odata/DD_Orders2
        public IHttpActionResult Post(DD_Orders dD_Orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DD_Orders.Add(dD_Orders);
            db.SaveChanges();

            return Created(dD_Orders);
        }

        // PATCH: odata/DD_Orders2(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<DD_Orders> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DD_Orders dD_Orders = db.DD_Orders.Find(key);
            if (dD_Orders == null)
            {
                return NotFound();
            }

            patch.Patch(dD_Orders);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DD_OrdersExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dD_Orders);
        }

        // DELETE: odata/DD_Orders2(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            DD_Orders dD_Orders = db.DD_Orders.Find(key);
            if (dD_Orders == null)
            {
                return NotFound();
            }

            db.DD_Orders.Remove(dD_Orders);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/DD_Orders2(5)/DD_customer
        //[EnableQuery]
        //public SingleResult<DD_customer> GetDD_customer([FromODataUri] int key)
        //{
        //    return SingleResult.Create(db.DD_Orders.Where(m => m.index == key).Select(m => m.DD_customer));
        //}

        // GET: odata/DD_Orders2(5)/DD_Order_detail
        [EnableQuery]
        public IQueryable<DD_Order_detail> GetDD_Order_detail([FromODataUri] int key)
        {
            return db.DD_Orders.Where(m => m.index == key).SelectMany(m => m.DD_Order_detail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DD_OrdersExists(int key)
        {
            return db.DD_Orders.Count(e => e.index == key) > 0;
        }
    }
}
