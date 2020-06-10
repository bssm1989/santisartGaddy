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

namespace santisart_app.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using santisart_app.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<DD_Order_detail>("DD_Order_detail1");
    builder.EntitySet<DD_Inventories>("DD_Inventories"); 
    builder.EntitySet<DD_Orders>("DD_Orders"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class DD_Order_detail1Controller : ODataController
    {
        private santisartEntities3 db = new santisartEntities3();

        // GET: odata/DD_Order_detail1
        [EnableQuery]
        public IQueryable<OrderDetailDto> GetDD_Order_detail1()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });

            var mapper = config.CreateMapper();
            return db.DD_Order_detail.ProjectTo<OrderDetailDto>(config).AsQueryable();
        }

        // GET: odata/DD_Order_detail1(5)
        [EnableQuery]
        public SingleResult<DD_Order_detail> GetDD_Order_detail([FromODataUri] int key)
        {
            return SingleResult.Create(db.DD_Order_detail.Where(dD_Order_detail => dD_Order_detail.index == key));
        }

        // PUT: odata/DD_Order_detail1(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<DD_Order_detail> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DD_Order_detail dD_Order_detail = db.DD_Order_detail.Find(key);
            if (dD_Order_detail == null)
            {
                return NotFound();
            }

            patch.Put(dD_Order_detail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DD_Order_detailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dD_Order_detail);
        }

        // POST: odata/DD_Order_detail1
        public IHttpActionResult Post(DD_Order_detail dD_Order_detail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DD_Order_detail.Add(dD_Order_detail);
            db.SaveChanges();

            return Created(dD_Order_detail);
        }

        // PATCH: odata/DD_Order_detail1(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<DD_Order_detail> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DD_Order_detail dD_Order_detail = db.DD_Order_detail.Find(key);
            if (dD_Order_detail == null)
            {
                return NotFound();
            }

            patch.Patch(dD_Order_detail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DD_Order_detailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dD_Order_detail);
        }

        // DELETE: odata/DD_Order_detail1(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            DD_Order_detail dD_Order_detail = db.DD_Order_detail.Find(key);
            if (dD_Order_detail == null)
            {
                return NotFound();
            }

            db.DD_Order_detail.Remove(dD_Order_detail);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/DD_Order_detail1(5)/DD_Inventories
        [EnableQuery]
        public SingleResult<DD_Inventories> GetDD_Inventories([FromODataUri] int key)
        {
            return SingleResult.Create(db.DD_Order_detail.Where(m => m.index == key).Select(m => m.DD_Inventories));
        }

        // GET: odata/DD_Order_detail1(5)/DD_Orders
        [EnableQuery]
        public SingleResult<DD_Orders> GetDD_Orders([FromODataUri] int key)
        {
            return SingleResult.Create(db.DD_Order_detail.Where(m => m.index == key).Select(m => m.DD_Orders));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DD_Order_detailExists(int key)
        {
            return db.DD_Order_detail.Count(e => e.index == key) > 0;
        }
    }
}
