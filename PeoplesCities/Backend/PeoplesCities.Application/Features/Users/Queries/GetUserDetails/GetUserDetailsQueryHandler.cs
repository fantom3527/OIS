using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PeoplesCities.Application.Common.Exception;
using PeoplesCities.Application.Interfaces;
using PeoplesCities.Domain;

namespace PeoplesCities.Application.Features.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsVm>
    {
        private readonly IPeoplesCitiesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserDetailsQueryHandler(IPeoplesCitiesDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UserDetailsVm> Handle(GetUserDetailsQuery requst, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == requst.Id, cancellationToken);

            if (entity == null || entity.Id != requst.Id)
            {
                throw new NotFoundException(nameof(User), requst.Id);
            }

            return _mapper.Map<UserDetailsVm>(entity);
        }
    }
}
