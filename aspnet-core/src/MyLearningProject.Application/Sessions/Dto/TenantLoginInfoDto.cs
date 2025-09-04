using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyLearningProject.MultiTenancy;

namespace MyLearningProject.Sessions.Dto;

[AutoMapFrom(typeof(Tenant))]
public class TenantLoginInfoDto : EntityDto
{
    public string TenancyName { get; set; }

    public string Name { get; set; }
}
