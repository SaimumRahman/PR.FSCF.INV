using AutoMapper;
using JM.Domain.Entities;
using JM.Domain.RTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM.Application.Services.Supplier_S
{
    public class SupplierMappingProfile : Profile
    {
        public SupplierMappingProfile() 
        {
           // CreateMap<SourceClass, DestinationClass>();
            CreateMap<SupplierRTO, Supplier>();
        } 
    }
}
