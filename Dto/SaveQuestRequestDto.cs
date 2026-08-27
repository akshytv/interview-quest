namespace InterviewQuest.API.Dto;

public class SaveQuestRequestDto
{
    public Guid? CacheId {get; set;}

    public Guid UserId {get; set;}

    public required string Metadata {get; set;}
}