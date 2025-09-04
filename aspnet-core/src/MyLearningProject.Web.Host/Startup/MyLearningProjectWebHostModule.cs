using Abp.Modules;
using Abp.Reflection.Extensions;
using MyLearningProject.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MyLearningProject.Web.Host.Startup
{
    [DependsOn(
       typeof(MyLearningProjectWebCoreModule))]
    public class MyLearningProjectWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MyLearningProjectWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyLearningProjectWebHostModule).GetAssembly());
        }
    }
}
