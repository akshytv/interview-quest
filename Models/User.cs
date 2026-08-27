namespace InterviewQuest.API.Models;

/// <summary>
/// Entity representing Users
/// </summary>
public class User: BaseModel
{
    public Guid Id {get; set;}

    public required string UserId {get; set;}
}