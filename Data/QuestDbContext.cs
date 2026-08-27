using interviewQuest.API.Models;
using InterviewQuest.API.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewQuest.API.Data;
public class QuestDbContext(DbContextOptions<QuestDbContext> options): DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    public DbSet<StatsCache> StatsCaches => Set<StatsCache>();
}