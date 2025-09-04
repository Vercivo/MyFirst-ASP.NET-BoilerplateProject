using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace MyLearningProject.EntityFrameworkCore;

public static class MyLearningProjectDbContextConfigurer
{
    public static void Configure(DbContextOptionsBuilder<MyLearningProjectDbContext> builder, string connectionString)
    {
        builder.UseSqlServer(connectionString);
    }

    public static void Configure(DbContextOptionsBuilder<MyLearningProjectDbContext> builder, DbConnection connection)
    {
        builder.UseSqlServer(connection);
    }
}
