using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PeoplesCities.Application.Common.Query;
using PeoplesCities.Application.Interfaces;

namespace PeoplesCities.Application.Features.Cities.Queries.GetCityList
{
    public class GetCityListQueryHandler : IRequestHandler<GetEmptyQuery, CityListVm>
    {
        private readonly IPeoplesCitiesDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetCityListQueryHandler(IPeoplesCitiesDbContext dbcontext, IMapper mapper) => 
            (_dbcontext, _mapper) = (dbcontext, mapper);


        public async Task<CityListVm> Handle(GetEmptyQuery _, CancellationToken cancellationToken)
        {
            var citiesQuery = await _dbcontext.Cities.ProjectTo<CityLookupDto>(_mapper.ConfigurationProvider)
                                                     .ToListAsync(cancellationToken);

            return new CityListVm { Cities = citiesQuery };
        }
    }
}
