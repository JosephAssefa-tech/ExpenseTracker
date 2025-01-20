using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ExpenseTrackerApplicationLayer.Models.Categories.Commands;
using ExpenseTrackerApplicationLayer.Models.Categories.Dtos;
using ExpenseTrackerDomainLayer.Entities;

namespace ExpenseTrackerApplicationLayer.Models.Categories.AutoMapper
{
    public class CategoryMappingProfile : Profile
    { 
        public CategoryMappingProfile() { 
            CreateMap<CreateCategoryCommand , Category>().ReverseMap();
            CreateMap<DeleteCategoryCommand , Category>().ReverseMap();
            CreateMap<UpdateCategoryCommand , Category>().ReverseMap();
            CreateMap<CategoryDto , Category>().ReverseMap();
        
        }
    }
}
