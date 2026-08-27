using InterviewQuest.API.Data;
using InterviewQuest.API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InterviewQuest.API.Requests.Commands;
public class RegisterUserCommand: IRequest<bool>
{
    public Guid Id {get; set;}

    public required string UserId {get; set;}
}

public class RegisterUserCommandHandler(QuestDbContext dbContext) : IRequestHandler<RegisterUserCommand, bool>
{
    public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        bool userExists = await dbContext.Users
            .AnyAsync(u => u.UserId == request.UserId, cancellationToken);

        if (userExists)
        {
            return false;
        }

        dbContext.Users.Add(
            new User
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            }
        );

        await dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}