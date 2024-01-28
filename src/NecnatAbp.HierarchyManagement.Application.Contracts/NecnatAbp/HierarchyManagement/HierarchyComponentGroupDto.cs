using NecnatAbp.Dtos;
using System;

namespace NecnatAbp.HierarchyManagement
{
    public class HierarchyComponentGroupDto : ConcurrencyAuditedEntityDto<Guid>
    {
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
    }
}
