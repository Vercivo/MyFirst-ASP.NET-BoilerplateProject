using Abp.Application.Services;
using MyLearningProject.MultiTenancy.Dto;

namespace MyLearningProject.MultiTenancy;

public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
{
}

