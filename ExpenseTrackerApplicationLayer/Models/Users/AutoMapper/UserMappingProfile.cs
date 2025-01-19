using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ExpenseTrackerApplicationLayer.Models.Budgets.ResponseDto;
using ExpenseTrackerApplicationLayer.Models.Users.Commands;
using ExpenseTrackerApplicationLayer.Models.Users.Dtos;
using ExpenseTrackerDomainLayer.Entities;

namespace ExpenseTrackerApplicationLayer.Models.Users.AutoMapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() { 

        CreateMap<CreateUserCommand,User>().ReverseMap();
        CreateMap<UpdateUserCommand,User>().ReverseMap();
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<ListBudgetResponseDto, Budget>().ReverseMap();
            

        }
    }
}
