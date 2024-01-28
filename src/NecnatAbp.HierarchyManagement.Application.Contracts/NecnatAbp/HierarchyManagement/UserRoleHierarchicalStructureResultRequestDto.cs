using NecnatAbp.Dtos;
using System;

namespace NecnatAbp.HierarchyManagement
{
    public class UserRoleHierarchicalStructureResultRequestDto : OptionalPagedAndSortedResultRequestDto
    {
        public Guid? UserId { get; set; }
        public Guid? RoleId { get; set; }
        public Guid? HierarchicalStructureId { get; set; }
    }
}
