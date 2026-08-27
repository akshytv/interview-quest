namespace InterviewQuest.API.Models;

/// <summary>
/// Base class of all entity classes.
/// </summary>
public class BaseModel
{
    public DateTime CreatedOn {get; set;}

    public Guid CreatedBy {get; set;}

    public DateTime ModifiedOn {get; set;}

    public Guid ModifiedBy  {get; set;}
}