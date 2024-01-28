using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace NecnatAbp.HierarchyManagement
{
    public interface IHierarchyAuthRepository : IRepository
    {
        Task<List<Guid?>> SearchHierarchicalStructureIdAsync(Guid userId, string permissionName);
        Task CheckByHierarchicalStructureIdAsync(Guid userId, string permissionName, Guid? hierarchicalStructureId);        
    }
}
