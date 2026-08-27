using interviewQuest.API.Models;
using InterviewQuest.API.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace InterviewQuest.API.Requests.Commands;
public class SaveQuestDataCommand: IRequest<bool>
{
    public Guid? CacheId {get; set;}

    public Guid UserId {get; set;}

    public required string Metadata {get; set;}
}

public class SaveQuestDataCommandHandler(QuestDbContext dbContext) : IRequestHandler<SaveQuestDataCommand, bool>
{
    public async Task<bool> Handle(SaveQuestDataCommand request, CancellationToken cancellationToken)
    {
        if(request.CacheId == null)
        {
            dbContext.StatsCaches.Add(
                new StatsCache
                {
                    Id = Guid.NewGuid(),
                    UserId = request.UserId,
                    Metadata = request.Metadata
                }
            );
        }
        else {
            var cache = await dbContext.StatsCaches
                .FirstOrDefaultAsync(s => s.Id == request.CacheId, cancellationToken);

            if (cache == null)
            {
                return false;
            }

            cache.Metadata = request.Metadata;
            cache.ModifiedOn = DateTime.UtcNow;
        }

        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}