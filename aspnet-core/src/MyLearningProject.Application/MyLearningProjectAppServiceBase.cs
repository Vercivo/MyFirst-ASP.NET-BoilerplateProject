using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using MyLearningProject.Authorization.Users;
using MyLearningProject.MultiTenancy;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace MyLearningProject;

/// <summary>
/// Derive your application services from this class.
/// </summary>
public abstract class MyLearningProjectAppServiceBase : ApplicationService
{
    public TenantManager TenantManager { get; set; }

    public UserManager UserManager { get; set; }

    protected MyLearningProjectAppServiceBase()
    {
        LocalizationSourceName = MyLearningProjectConsts.LocalizationSourceName;
    }

    protected virtual async Task<User> GetCurrentUserAsync()
    {
        var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
        if (user == null)
        {
            throw new Exception("There is no current user!");
        }

        return user;
    }

    protected virtual Task<Tenant> GetCurrentTenantAsync()
    {
        return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
    }

    protected virtual void CheckErrors(IdentityResult identityResult)
    {
        identityResult.CheckErrors(LocalizationManager);
    }
}
