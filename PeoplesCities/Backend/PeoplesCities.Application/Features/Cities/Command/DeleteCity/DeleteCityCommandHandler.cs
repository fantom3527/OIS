using MediatR;
using PeoplesCities.Application.Common.Exception;
using PeoplesCities.Application.Interfaces;
using PeoplesCities.Domain;

namespace PeoplesCities.Application.Features.Cities.Command.DeleteCity
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, Unit>
    {
        private readonly IPeoplesCitiesDbContext _dbcontext;

        public DeleteCityCommandHandler(IPeoplesCitiesDbContext dbcontext) => 
            _dbcontext = dbcontext;

        public async Task<Unit> Handle(DeleteCityCommand requst, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Cities.FindAsync(new object[] { requst.Id }, cancellationToken);

            if (entity == null || entity.Id != requst.Id)
            {
                throw new NotFoundException(nameof(City), requst.Id);
            }

            _dbcontext.Cities.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
