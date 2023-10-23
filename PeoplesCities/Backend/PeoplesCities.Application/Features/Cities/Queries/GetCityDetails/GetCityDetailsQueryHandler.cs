using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PeoplesCities.Application.Common.Exception;
using PeoplesCities.Application.Interfaces;
using PeoplesCities.Domain;

namespace PeoplesCities.Application.Features.Cities.Queries.GetCityDetails
{
    public class GetCityDetailsQueryHandler : IRequestHandler<GetCityDetailsQuery, CityDetailsVm>
    {
        private readonly IPeoplesCitiesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCityDetailsQueryHandler(IPeoplesCitiesDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CityDetailsVm> Handle(GetCityDetailsQuery requst, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Cities.FirstOrDefaultAsync(city => city.Id == requst.Id, cancellationToken);

            if (entity == null || entity.Id != requst.Id)
            {
                throw new NotFoundException(nameof(City), requst.Id);
            }

            return _mapper.Map<CityDetailsVm>(entity);
        }
    }
}
