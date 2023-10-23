using MediatR;
using PeoplesCities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplesCities.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Unit>
    {
       public User User { get; set; }
    }
}
