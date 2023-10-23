using MediatR;
using Microsoft.EntityFrameworkCore;
using PeoplesCities.Application.Common.Exception;
using PeoplesCities.Application.Interfaces;
using PeoplesCities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplesCities.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IPeoplesCitiesDbContext _dbcontext;

        public UpdateUserCommandHandler(IPeoplesCitiesDbContext dbcontext) => 
            _dbcontext = dbcontext;

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Users.FirstOrDefaultAsync(user => user.Id == request.User.Id, cancellationToken);

            if (entity == null || entity.Id != request.User.Id)
            {
                throw new NotFoundException(nameof(User), request.User.Id);
            }

            entity.CityId = request.User.CityId;
            entity.Name = request.User.Name;
            entity.Email = request.User.Email;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
