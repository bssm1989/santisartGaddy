using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using santisart_app.Dto;
using santisart_app.Models;
//using AutoMapper.Collection;

namespace santisart_app.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<DD_Orders, OrdersDto>();
            CreateMap<DD_Order_detail, OrderDetailDto>();
            CreateMap<DD_customer, CustomerDto>();
        }
    }
}