using System;
using System.Collections.Generic;

namespace NecnatAbp.HierarchyManagement
{
    public class HierarchyAutorizationModel
    {
        public Guid UserId { get; set; }
        public List<HamRolePermissionName> RolePermissionNameList { get; set; } = new List<HamRolePermissionName>();
        public List<HamRoleHierarchicalStructureId> RoleHierarchicalStructureIdList { get; set; } = new List<HamRoleHierarchicalStructureId>();
        public List<HamHierarchicalStructure> HierarchicalStructureList { get; set; } = new List<HamHierarchicalStructure>();
    }

    public class HamRolePermissionName
    {
        public Guid RoleId { get; set; }
        public List<string> PermissionNameList { get; set; } = new List<string>();
    }

    public class HamRoleHierarchicalStructureId
    {
        public Guid RoleId { get; set; }
        public List<Guid?> HierarchicalStructureIdList { get; set; } = new List<Guid?>();
    }

    public class HamHierarchicalStructure
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public Guid HierarchyId { get; set; }
        public int HierarchyComponentType { get; set; }
        public Guid HierarchyComponentId { get; set; }
    }

    public class HamHierarchyComponent
    {
        public int HierarchyComponentType { get; set; }
        public Guid HierarchyComponentId { get; set; }
    }
}
