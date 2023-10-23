using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeoplesCities.Application.Common.Query;
using PeoplesCities.Application.Features.Cities.Command.CreateCity;
using PeoplesCities.Application.Features.Cities.Command.DeleteCity;
using PeoplesCities.Application.Features.Cities.Command.UpdateCity;
using PeoplesCities.Application.Features.Cities.Queries.GetCityDetails;
using PeoplesCities.Application.Features.Cities.Queries.GetCityList;
using PeoplesCities.WebApi.Models.CityDto;

namespace PeoplesCities.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class CityController : BaseController
    {
        private readonly IMapper _mapper;

        public CityController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets all City.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /city/
        /// </remarks>
        /// <returns>Returns CityListVm.</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CityListVm>> GetAll()
        {
            var query = new GetEmptyQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Gets City by id.
        /// </summary>
        /// <param name="id">City id (guid).</param>
        /// <remarks>
        /// Sample request:
        /// GET /city/13360799-8908-4449-9CA9-64A3AA5AEA8C
        /// </remarks>
        /// <returns>Returns CityDetailsVm.</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CityDetailsVm>> Get(Guid id)
        {
            var query = new GetCityDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Creates the city.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /city
        /// {
        ///     name: "city name"
        ///     description: "city description"
        /// }
        /// </remarks>
        /// <param name="cityDto">CityDto object.</param>
        /// <returns>Returns id (guid).</returns>
        /// <response code="200">Success</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCityDto cityDto)
        {
            var command = _mapper.Map<CreateCityCommand>(cityDto);
            var cityId = await Mediator.Send(command);

            return Ok(cityId);
        }

        /// <summary>
        /// Updates the city.
        /// </summary>
        /// Sample request:
        /// <remarks>
        /// PUT /city
        /// {
        ///     name: "city name"
        ///     description: "city description"
        /// }
        /// </remarks>
        /// <param name="updateCityDto">UpdateCityDto object.</param>
        /// <returns>Return NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Update([FromBody] UpdateCityDto updateCityDto)
        {
            var command = _mapper.Map<UpdateCityCommand>(updateCityDto);
            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deletes the city by id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /city/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">City id (guid).</param>
        /// <returns>Returns NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteCityCommand
            {
                Id = id,
            };
            await Mediator.Send(command);

            return NoContent();
        }

    }
}
