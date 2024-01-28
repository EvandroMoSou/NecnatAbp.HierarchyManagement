using NecnatAbp.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

namespace NecnatAbp.HierarchyManagement
{
    public class CreateUpdateHierarchicalStructureDto : ConcurrencyDto
    {
        public Guid? ParentId { get; set; }

        [Required]
        public Guid HierarchyId { get; set; }

        [Required]
        public int HierarchyComponentType { get; set; }

        [Required]
        public Guid HierarchyComponentId { get; set; }
    }
}
