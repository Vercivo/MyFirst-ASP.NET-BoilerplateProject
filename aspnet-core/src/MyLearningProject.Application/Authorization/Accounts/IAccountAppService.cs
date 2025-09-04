﻿using Abp.Application.Services;
using MyLearningProject.Authorization.Accounts.Dto;
using System.Threading.Tasks;

namespace MyLearningProject.Authorization.Accounts;

public interface IAccountAppService : IApplicationService
{
    Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

    Task<RegisterOutput> Register(RegisterInput input);
}
