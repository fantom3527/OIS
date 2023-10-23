using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PeoplesCities.Application.Interfaces;

namespace PeoplesCities.Application.Features.Users.Queries.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListVm>
    {
        private readonly IPeoplesCitiesDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IPeoplesCitiesDbContext dbcontext, IMapper mapper) => (_dbcontext, _mapper) = (dbcontext, mapper);


        public async Task<UserListVm> Handle(GetUserListQuery requst, CancellationToken cancellationToken)
        {
            var usersQuery = await _dbcontext.Users
                .Where(user => user.CityId == requst.CityId)
                .ProjectTo<UserLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new UserListVm { Users = usersQuery };
        }
    }
}
