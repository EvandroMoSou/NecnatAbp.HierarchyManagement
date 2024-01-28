using System;
using Volo.Abp.Domain.Repositories;

namespace NecnatAbp.HierarchyManagement
{
    public interface IHierarchicalStructureRepository : IRepository<HierarchicalStructure, Guid>
    {

    }
}
