using NecnatAbp.AppServices;
using System;
using Volo.Abp.Application.Dtos;

namespace NecnatAbp.HierarchyManagement
{
    public interface IHierarchyComponentGroupAppService :
        ICrudsAppService<
            HierarchyComponentGroupDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateHierarchyComponentGroupDto,
            HierarchyComponentGroupResultRequestDto>
    {

    }
}
