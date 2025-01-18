using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerApplicationLayer.Models.Users.Dtos;
using MediatR;

namespace ExpenseTrackerApplicationLayer.Models.Users.Queries
{
    public class GetAllUsersQuery : IRequest<List<UserDto>>
    {
        public int? UserId { get; set; }
    }
}
