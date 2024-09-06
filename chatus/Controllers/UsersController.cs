using chatus.API.Models.Requests;
using chatus.API.Services;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IResult = Microsoft.AspNetCore.Http.IResult;

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
            return result.Match(
                Results.Ok,
                Results.BadRequest);
        }

        [HttpPost(nameof(Register))]
        public async Task<IResult> Register(RegisterUserRequest request)
        {
            var result = await _userService.Register(request.Login, request.Password, request.UserName);

            return result.Match(() => Results.Ok(), Results.BadRequest);
        }

        [HttpPost(nameof(Login))]
        public async Task<IResult> Login(LoginUserRequest request)
        {
            var token = await _userService.Login(request.Login, request.Password);

            return token.Match((value) => 
                { 
                    Response.Cookies.Append("woop-woop", value); 
                    return Results.Ok(value);
                }, 
                Results.BadRequest);

        }
    }
}
