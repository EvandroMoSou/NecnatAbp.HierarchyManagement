using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NecnatAbp.HierarchyManagement
{
    public interface IHierarchyAutorizationService
    {
        Task InitializeAsync();
        bool CheckPermission(string permissionName, int hierarchyComponentType, Guid hierarchyComponentId);
        List<Guid> AllowedHierarchicalStructureIdList(string permissionName);
        List<HamHierarchyComponent> AllowedHierarchyComponentList(string permissionName);
        HamHierarchyComponent? GetHierarchyComponentBy(Guid? hierarchicalStructureId);
        bool HasHierarchyComponentInHierarchicalStructure(Guid hierarchicalStructureId, int hierarchyComponentType, Guid hierarchyComponentId);
    }
}
