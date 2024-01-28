using NecnatAbp.Dtos;
using System;

namespace NecnatAbp.HierarchyManagement
{
    public class HierarchicalStructureResultRequestDto : OptionalPagedAndSortedResultRequestDto
    {
        public bool UseParentId { get; set; }
        public Guid? ParentId { get; set; }
        public Guid? HierarchyId { get; set; }
    }
}
