using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MyLearningProject.Controllers
{
    public abstract class MyLearningProjectControllerBase : AbpController
    {
        protected MyLearningProjectControllerBase()
        {
            LocalizationSourceName = MyLearningProjectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
