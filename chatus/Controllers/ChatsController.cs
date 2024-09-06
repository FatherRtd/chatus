using chatus.API.Models.Requests;
using chatus.API.Services;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace chatus.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IChatService _chatService;
        public ChatsController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet(nameof(ByUserId))]
        public async Task<IResult> ByUserId(Guid userId)
        {
            var result = await _chatService.GetUserChats(userId);

            return result.Match(Results.Ok, Results.BadRequest);
        }

        [HttpPost(nameof(CreateDialogue))]
        public async Task<IResult> CreateDialogue(CreateDialogueRequest request)
        {
            var userId = HttpContext.User.Claims.First(x => x.Type == "userId").Value;

            var result = await _chatService.CreateDialogue(new Guid(userId), new Guid(request.MemberId), request.InitialMessage);

            return result.Match(() => Results.Ok(), Results.BadRequest);
        }

        [HttpPost(nameof(CreateGroup))]
        public async Task<IResult> CreateGroup(CreateGroupRequest request)
        {
            var userId = HttpContext.User.Claims.First(x => x.Type == "userId").Value;

            var result = await _chatService.CreateGroup(request.Name, new Guid(userId));

            return result.Match(() => Results.Ok(), Results.BadRequest);
        }
    }
}
