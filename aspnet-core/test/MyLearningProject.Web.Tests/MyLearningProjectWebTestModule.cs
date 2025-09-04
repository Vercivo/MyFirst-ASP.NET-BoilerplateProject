using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyLearningProject.EntityFrameworkCore;
using MyLearningProject.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MyLearningProject.Web.Tests;

[DependsOn(
    typeof(MyLearningProjectWebMvcModule),
    typeof(AbpAspNetCoreTestBaseModule)
)]
public class MyLearningProjectWebTestModule : AbpModule
{
    public MyLearningProjectWebTestModule(MyLearningProjectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
    }

    public override void PreInitialize()
    {
        Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(MyLearningProjectWebTestModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        IocManager.Resolve<ApplicationPartManager>()
            .AddApplicationPartsIfNotAddedBefore(typeof(MyLearningProjectWebMvcModule).Assembly);
    }
}