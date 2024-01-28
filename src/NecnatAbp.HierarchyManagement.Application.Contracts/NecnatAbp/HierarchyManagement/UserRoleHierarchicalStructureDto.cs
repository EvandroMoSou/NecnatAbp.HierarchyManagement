using NecnatAbp.Dtos;
using System;

namespace NecnatAbp.HierarchyManagement
{
    public class UserRoleHierarchicalStructureDto : ConcurrencyAuditedEntityDto<Guid>
    {
        public Guid? UserId { get; set; }
        public string? UserUserName { get; set; }
        public Guid? RoleId { get; set; }
        public Guid? HierarchicalStructureId { get; set; }
    }
}
