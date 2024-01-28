using NecnatAbp.Dtos;
using System;

namespace NecnatAbp.HierarchyManagement
{
    public class HierarchicalStructureDto : ConcurrencyAuditedEntityDto<Guid>
    {
        public Guid? ParentId { get; set; }
        public Guid? HierarchyId { get; set; }
        public int? HierarchyComponentType { get; set; }
        public Guid? HierarchyComponentId { get; set; }
    }
}
