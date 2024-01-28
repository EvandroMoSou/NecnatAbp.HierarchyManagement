using NecnatAbp.AppServices;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace NecnatAbp.HierarchyManagement
{
    public interface INecnatRoleAppService :
        ICrudsAppService<
            IdentityRoleDto,
            Guid,
            PagedAndSortedResultRequestDto,
            IdentityRoleDto,
            NecnatRoleResultRequestDto>,
        IGetAndSearchAppService<IdentityRoleDto, Guid, NecnatRoleResultRequestDto>
    {

    }
}
