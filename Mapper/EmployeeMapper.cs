using System;
using AutoMapper;
using EmloyeePortal.Model.Domain;
using EmloyeePortal.Model.Dto;

namespace EmloyeePortal.Mapper
{
    public class EmployeeMapper : Profile
    {

        public EmployeeMapper()
        {
            CreateMap<EmployeeDto, Employee>();
        }
    }
}

