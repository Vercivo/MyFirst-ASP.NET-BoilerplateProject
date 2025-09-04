using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyLearningProject.Configuration;
using MyLearningProject.EntityFrameworkCore;
using MyLearningProject.Migrator.DependencyInjection;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;

namespace MyLearningProject.Migrator;

[DependsOn(typeof(MyLearningProjectEntityFrameworkModule))]
public class MyLearningProjectMigratorModule : AbpModule
{
    private readonly IConfigurationRoot _appConfiguration;

    public MyLearningProjectMigratorModule(MyLearningProjectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

        _appConfiguration = AppConfigurations.Get(
            typeof(MyLearningProjectMigratorModule).GetAssembly().GetDirectoryPathOrNull()
        );
    }

    public override void PreInitialize()
    {
        Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
            MyLearningProjectConsts.ConnectionStringName
        );

        Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        Configuration.ReplaceService(
            typeof(IEventBus),
            () => IocManager.IocContainer.Register(
                Component.For<IEventBus>().Instance(NullEventBus.Instance)
            )
        );
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(MyLearningProjectMigratorModule).GetAssembly());
        ServiceCollectionRegistrar.Register(IocManager);
    }
}
