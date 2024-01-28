using NecnatAbp.AppServices;
using System;
using Volo.Abp.Application.Dtos;

namespace NecnatAbp.HierarchyManagement
{
    public interface IUserRoleHierarchicalStructureAppService :
        ICrudsAppService<
            UserRoleHierarchicalStructureDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateUserRoleHierarchicalStructureDto,
            UserRoleHierarchicalStructureResultRequestDto>
    {

    }
}
