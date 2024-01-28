using NecnatAbp.Dtos;
using System.ComponentModel.DataAnnotations;

namespace NecnatAbp.HierarchyManagement
{
    public class CreateUpdateHierarchyComponentGroupDto : ConcurrencyDto
    {
        [Required]
        [StringLength(HierarchyComponentGroupConsts.MaxNameLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; }
    }
}
