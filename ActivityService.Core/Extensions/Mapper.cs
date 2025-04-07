using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PayrollService.Core.Domain.Entities;
using PayrollService.Core.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PayrollService.Core.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SalaryBase, SalaryBaseDTO>();
            CreateMap<SalaryBaseDTO, SalaryBase>();
            CreateMap<SalaryHist, ActivityRequest>();
            CreateMap<ActivityRequest, SalaryHist>();
            CreateMap<SalaryAdjustment, SalaryAdjustmentDTO>();
            CreateMap<SalaryAdjustmentDTO, SalaryAdjustment>();
            CreateMap<SalaryPayment, DTO.AttendanceDTO>();
            CreateMap<DTO.AttendanceDTO, SalaryPayment>();

        }
    }
}
