using MediatR;
using PeoplesCities.Application.Interfaces;
using PeoplesCities.Domain;

namespace PeoplesCities.Application.Features.Cities.Command.CreateCity
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, Guid>
    {
        private readonly IPeoplesCitiesDbContext _dbContext;

        public CreateCityCommandHandler(IPeoplesCitiesDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateCityCommand requst, CancellationToken cancellationToken)
        {
            //TODO: переделать на логирование
            try
            {
                var city = new City()
                {
                    Id = requst.City.Id,
                    Name = requst.City.Name,
                    Description = requst.City.Description,
                };

                await _dbContext.Cities.AddAsync(city, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return city.Id;
            }
            catch (Exception ex)
            {
                // Зарегистрировать внутреннее исключение
                Console.WriteLine("Inner Exception: " + ex.InnerException?.Message);
                throw;
            }
        }
    }
}
