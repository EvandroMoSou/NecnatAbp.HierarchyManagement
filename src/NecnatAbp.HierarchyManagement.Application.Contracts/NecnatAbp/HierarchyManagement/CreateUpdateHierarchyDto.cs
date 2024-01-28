using NecnatAbp.Dtos;
using System.ComponentModel.DataAnnotations;

namespace NecnatAbp.HierarchyManagement
{
    public class CreateUpdateHierarchyDto : ConcurrencyDto
    {
        [Required]
        [StringLength(HierarchyConsts.MaxNameLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; }
    }
}
