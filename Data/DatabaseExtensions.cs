using InterviewQuest.API.Data;

namespace InterviewQuest.API.Data;

public static class DatabaseExtensions
{
    public static void AddQuestDb(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("Quest");
        builder.Services.AddSqlite<QuestDbContext>(connectionString);
    }
}