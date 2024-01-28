using NecnatAbp.Dtos;

namespace NecnatAbp.HierarchyManagement
{
    public class HierarchyResultRequestDto : OptionalPagedAndSortedResultRequestDto
    {
        public string? NameContains { get; set; }
        public bool? IsActive { get; set; }
    }
}
