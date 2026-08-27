using InterviewQuest.API.Dto;
using InterviewQuest.API.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InterviewQuest.API.Controllers;

[ApiController]
[Route("quest")]
public class QuestPlaceholderData(IMediator mediator): ControllerBase
{
    [HttpPost]
    [Route("save")]
    public async Task<IActionResult> SaveQuestData([FromBody] SaveQuestRequestDto request)
    {
        var command = new SaveQuestDataCommand
        {
            CacheId = request.CacheId,
            UserId = request.UserId,
            Metadata = request.Metadata
        };

        bool result = await mediator.Send(command);

        return Ok(result);
    }
}