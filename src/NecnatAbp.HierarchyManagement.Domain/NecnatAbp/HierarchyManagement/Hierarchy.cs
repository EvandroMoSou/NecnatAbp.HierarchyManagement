using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace NecnatAbp.HierarchyManagement
{
    public class Hierarchy : AuditedAggregateRoot<Guid>
    {
        public virtual string Name { get; set; } = string.Empty;
        public virtual bool IsActive { get; set; }
    }
}
