using MediatR;
using PeoplesCities.Application.Common.Exception;
using PeoplesCities.Application.Interfaces;
using PeoplesCities.Domain;

namespace PeoplesCities.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IPeoplesCitiesDbContext _dbcontext;

        public DeleteUserCommandHandler(IPeoplesCitiesDbContext dbcontext) => 
            _dbcontext = dbcontext;

        public async Task<Unit> Handle(DeleteUserCommand requst, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Users.FindAsync(new object[] { requst.Id }, cancellationToken);

            if (entity == null || entity.Id != requst.Id)
            {
                throw new NotFoundException(nameof(User), requst.Id);
            }

            _dbcontext.Users.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
