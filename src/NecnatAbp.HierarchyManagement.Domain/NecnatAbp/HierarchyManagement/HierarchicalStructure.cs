using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace NecnatAbp.HierarchyManagement
{
    public class HierarchicalStructure : AuditedAggregateRoot<Guid>
    {
        public virtual Guid? ParentId { get; set; }
        public virtual HierarchicalStructure? Parent { get; set; }
        public virtual Guid HierarchyId { get; set; }
        public virtual Hierarchy? Hierarchy { get; set; }
        public virtual int HierarchyComponentType { get; set; }
        public virtual Guid HierarchyComponentId { get; set; }
    }
}
