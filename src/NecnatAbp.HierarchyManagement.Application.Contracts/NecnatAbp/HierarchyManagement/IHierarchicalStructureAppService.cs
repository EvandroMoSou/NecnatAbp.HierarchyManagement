using NecnatAbp.AppServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace NecnatAbp.HierarchyManagement
{
    public interface IHierarchicalStructureAppService :
        ICrudsAppService<
            HierarchicalStructureDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateHierarchicalStructureDto,
            HierarchicalStructureResultRequestDto>
    {
        Task<List<HierarchyComponentDto>> ListHierarchyComponentAsync();
        Task<List<HierarchyComponentTypeDto>> ListHierarchyComponentTypeAsync();
    }
}
