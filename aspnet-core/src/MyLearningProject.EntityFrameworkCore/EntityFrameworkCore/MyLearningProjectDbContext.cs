using Abp.Zero.EntityFrameworkCore;
using MyLearningProject.Authorization.Roles;
using MyLearningProject.Authorization.Users;
using MyLearningProject.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using MyLearningProject.Entities.People;
using MyLearningProject.Entities.Books;

namespace MyLearningProject.EntityFrameworkCore;

public class MyLearningProjectDbContext : AbpZeroDbContext<Tenant, Role, User, MyLearningProjectDbContext>
{
    /* Define a DbSet for each entity of the application */

    public MyLearningProjectDbContext(DbContextOptions<MyLearningProjectDbContext> options)
        : base(options)
    {
    }

    public DbSet<Person> People { get; set; }
    public DbSet<Book> Books { get; set; }

}
