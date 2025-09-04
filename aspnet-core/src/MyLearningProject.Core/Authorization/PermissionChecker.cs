using Abp.Authorization;
using MyLearningProject.Authorization.Roles;
using MyLearningProject.Authorization.Users;

namespace MyLearningProject.Authorization;

public class PermissionChecker : PermissionChecker<Role, User>
{
    public PermissionChecker(UserManager userManager)
        : base(userManager)
    {
    }
}
