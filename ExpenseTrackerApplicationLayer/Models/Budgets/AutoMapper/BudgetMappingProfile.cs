using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ExpenseTrackerApplicationLayer.Models.Budgets.Commands;
using ExpenseTrackerDomainLayer.Entities;

namespace ExpenseTrackerApplicationLayer.Models.Budgets.AutoMapper
{
    public class BudgetMappingProfile : Profile
    {
        public BudgetMappingProfile() { 
            CreateMap<CreateBudgetCommand, Budget>().ReverseMap();
            CreateMap<UpdateBudgetCommand, Budget>().ReverseMap();
        
        }
    }
}
