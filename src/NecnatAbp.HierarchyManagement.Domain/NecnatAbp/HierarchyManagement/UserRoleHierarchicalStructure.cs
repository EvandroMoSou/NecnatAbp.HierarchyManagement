using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace NecnatAbp.HierarchyManagement
{
    public class UserRoleHierarchicalStructure : AuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid UserId { get; set; }
        public virtual Guid RoleId { get; set; }
        public virtual Guid? HierarchicalStructureId { get; set; }
        public virtual Guid? TenantId { get; set; }
    }
}
