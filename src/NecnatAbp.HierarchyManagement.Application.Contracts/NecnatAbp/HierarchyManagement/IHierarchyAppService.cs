using NecnatAbp.AppServices;
using System;
using Volo.Abp.Application.Dtos;

namespace NecnatAbp.HierarchyManagement
{
    public interface IHierarchyAppService :
        ICrudsAppService<
            HierarchyDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateHierarchyDto,
            HierarchyResultRequestDto>,
        IGetAndSearchAppService<HierarchyDto, Guid, HierarchyResultRequestDto>
    {

    }
}
