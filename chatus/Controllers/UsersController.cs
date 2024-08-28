using chatus.API.Contracts;
using chatus.API.Dto;
using chatus.API.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chatus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("byId")]
        public async Task<IResult> GetById(Guid id)
        {
            var result = await _userService.GetById(id);
            if (result.IsFailure)
            {
                return Results.Problem(new ProblemDetails
                {
                    Status = 400,
                    Detail = result.Error,
                });
            }

            return Results.Ok(result.Value.Adapt<UserDto>());
        }

        [HttpGet(nameof(TestError))]
        public IResult TestError()
        {
            return Results.Problem("error");
        }

        [HttpPost(nameof(Register))]
        public async Task<IResult> Register(RegisterUserRequest request)
        {
            var result = await _userService.Register(request.Login, request.Password, request.UserName);

            if (result.IsFailure)
            {
                return Results.Problem(new ProblemDetails
                {
                    Status = 400,
                    Detail = result.Error
                });
            }

            return Results.Ok();
        }

        [HttpPost(nameof(Login))]
        public async Task<IResult> Login(LoginUserRequest request)
        {
            var token = await _userService.Login(request.Login, request.Password);

            if (token.IsFailure)
            {
                return Results.Problem(new ProblemDetails
                {
                    Status = 400,
                    Detail = token.Error
                });
            }

            Response.Cookies.Append("woop-woop", token.Value);

            return Results.Ok(token.Value);
        }
    }
}
