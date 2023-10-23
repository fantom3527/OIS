using MediatR;
using Microsoft.EntityFrameworkCore;
using PeoplesCities.Application.Common.Exception;
using PeoplesCities.Application.Interfaces;
using PeoplesCities.Domain;

namespace PeoplesCities.Application.Features.Cities.Command.UpdateCity
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, Unit>
    {
        private readonly IPeoplesCitiesDbContext _dbcontext;

        public UpdateCityCommandHandler(IPeoplesCitiesDbContext dbcontext) => 
            _dbcontext = dbcontext;

        public async Task<Unit> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Cities.FirstOrDefaultAsync(city => city.Id == request.City.Id, cancellationToken);

            if (entity == null || entity.Id != request.City.Id)
            {
                throw new NotFoundException(nameof(City), request.City.Id);
            }

            entity.Name = request.City.Name;
            entity.Description = request.City.Description;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
