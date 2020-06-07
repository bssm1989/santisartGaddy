using AutoMapper;
using Newtonsoft.Json.Serialization;
using santisart_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using santisart_app.App_Start;
using santisart_app.Dto;

namespace santisart_app.Controllers.OData
{
    public class testController : ApiController
    {
        private santisartEntities3 db = new santisartEntities3();

        // GET: api/test
        public IEnumerable<OrdersDto> getOrder()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });

            var mapper = config.CreateMapper();

            var getLIst = db.DD_Orders.Select(mapper.Map<DD_Orders, OrdersDto>).AsEnumerable();
            return getLIst;
        }
    }
}
