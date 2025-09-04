using Abp.Application.Services;
using MyLearningProject.Sessions.Dto;
using System.Threading.Tasks;

namespace MyLearningProject.Sessions;

public interface ISessionAppService : IApplicationService
{
    Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
}
