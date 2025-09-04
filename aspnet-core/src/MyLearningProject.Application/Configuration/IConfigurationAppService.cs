using MyLearningProject.Configuration.Dto;
using System.Threading.Tasks;

namespace MyLearningProject.Configuration;

public interface IConfigurationAppService
{
    Task ChangeUiTheme(ChangeUiThemeInput input);
}
