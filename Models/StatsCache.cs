using System.Text.Json;
using InterviewQuest.API.Models;

namespace interviewQuest.API.Models;
/// <summary>
/// Entity representing stats cache.
/// </summary>
public class StatsCache: BaseModel
{
    public Guid Id {get; set;}

    public Guid UserId {get; set;}

    public required string Metadata {get; set;}
}