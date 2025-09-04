using Abp.Authorization;
using Abp.Runtime.Session;
using MyLearningProject.Configuration.Dto;
using System.Threading.Tasks;

namespace MyLearningProject.Configuration;

[AbpAuthorize]
public class ConfigurationAppService : MyLearningProjectAppServiceBase, IConfigurationAppService
{
    public async Task ChangeUiTheme(ChangeUiThemeInput input)
    {
        await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
    }
}
