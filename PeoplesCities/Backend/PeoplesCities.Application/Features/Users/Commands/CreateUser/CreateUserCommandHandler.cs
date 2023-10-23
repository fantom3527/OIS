using MediatR;
using PeoplesCities.Application.Interfaces;
using PeoplesCities.Domain;

namespace PeoplesCities.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IPeoplesCitiesDbContext _dbContext;

        public CreateUserCommandHandler(IPeoplesCitiesDbContext dbContext) => 
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateUserCommand requst, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User()
                {
                    Id = requst.User.Id,
                    CityId = requst.User.CityId,
                    Name = requst.User.Name,
                    Email = requst.User.Email,
                };

                await _dbContext.Users.AddAsync(user, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return user.Id;
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
