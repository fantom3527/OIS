using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeoplesCities.Application.Features.Users.Commands.CreateUser;
using PeoplesCities.Application.Features.Users.Commands.DeleteUser;
using PeoplesCities.Application.Features.Users.Commands.UpdateUser;
using PeoplesCities.Application.Features.Users.Queries.GetUserDetails;
using PeoplesCities.Application.Features.Users.Queries.GetUserList;
using PeoplesCities.WebApi.Models.UserDto;

namespace PeoplesCities.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets user by cityId.
        /// </summary>
        /// <param name="cityId">City id (guid).</param>
        /// <remarks>
        /// Sample request:
        /// GET /user/f278d99c-2876-4bfd-b6b9-1b901bed4267
        /// </remarks>
        /// <returns>Returns UserListVm.</returns>
        /// <response code="200">Success</response>
        [HttpGet("by-city-id/{cityId}")]
        [ActionName("GetByCity")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserListVm>> GetByCity(Guid cityId)
        {
            var query = new GetUserListQuery()
            {
                CityId = cityId
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Gets user by id.
        /// </summary>
        /// <param name="id">User id (guid).</param>
        /// <remarks>
        /// Sample request:
        /// GET /user/13360799-8908-4449-9CA9-64A3AA5AEA8C
        /// </remarks>
        /// <returns>Returns UserDetailsVm.</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ActionName("Get")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserDetailsVm>> Get(Guid id)
        {
            var query = new GetUserDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /user
        /// {
        ///     cityid: "user's cityid"
        ///     name:   "user name"
        ///     Email:  "user description"
        /// }
        /// </remarks>
        /// <param name="userDto">UserDto object.</param>
        /// <returns>Returns id (guid).</returns>
        /// <response code="200">Success</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserDto userDto)
        {
            var command = _mapper.Map<CreateUserCommand>(userDto);
            var userId = await Mediator.Send(command);

            return Ok(userId);
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /user
        /// {
        ///     Id:          "user id"  
        ///     name:        "user name"
        ///     description: "user description"
        /// }
        /// </remarks>
        /// <param name="updateUserDto">UpdateUserDto object.</param>
        /// <returns>Return NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Update([FromBody] UpdateUserDto updateUserDto)
        {
            var command = _mapper.Map<UpdateUserCommand>(updateUserDto);
            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deletes the user by id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /user/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">user id (guid).</param>
        /// <returns>Returns NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand
            {
                Id = id,
            };
            await Mediator.Send(command);

            return NoContent();
        }

    }
}
