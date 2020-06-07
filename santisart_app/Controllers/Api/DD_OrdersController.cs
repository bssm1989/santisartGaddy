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
using santisart_app.App_Start;
using santisart_app.Dto;
using santisart_app.Models;
using AutoMapper.QueryableExtensions;
namespace santisart_app.Controllers.Api
{
    public class DD_OrdersController : ApiController
    {
        private santisartEntities3 db = new santisartEntities3();

        // GET: api/DD_Orders
        public IQueryable<OrdersDto> GetDD_Orders()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });

            var mapper = config.CreateMapper();
            //Mapper.Map<DD_Orders, OrdersDto>();
            //var getLIst = db.DD_Orders.Select(mapper.Map<DD_Orders, OrdersDto>).AsQueryable();
            //return mapper.Map < DD_Orders,OrdersDto >(db.DD_Orders);
            return db.DD_Orders.ProjectTo<OrdersDto>(config).AsQueryable().Where(x => x.Order_status != "Canceled");//.ProjectTo<OrdersDto>();
        }


        // GET: api/DD_Orders/5
        [ResponseType(typeof(DD_Orders))]
        public IHttpActionResult GetDD_Orders(int id)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();

  
            DD_Orders dD_Orders = db.DD_Orders.Find(id);
            if (dD_Orders == null)
            {
                return NotFound();
            }

            return Ok( mapper.Map<DD_Orders,OrdersDto>(dD_Orders));
        }

        // PUT: api/DD_Orders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDD_Orders(int id, OrdersDto  orderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderDto.index)
            {
                return BadRequest();
            }

            db.Entry(orderDto).State = EntityState.Modified;

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
        public IHttpActionResult PostDD_Orders(OrdersDto orderDto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper(); 

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var order = mapper.Map<OrdersDto, DD_Orders>(orderDto);
            db.DD_Orders.Add(order);
            db.SaveChanges();
            orderDto.index = order.index;
            return CreatedAtRoute("DefaultApi", new { id = order.index }, order);
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