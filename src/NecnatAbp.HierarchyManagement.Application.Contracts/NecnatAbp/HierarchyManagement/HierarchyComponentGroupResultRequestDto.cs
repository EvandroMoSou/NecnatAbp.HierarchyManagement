using NecnatAbp.Dtos;

namespace NecnatAbp.HierarchyManagement
{
    public class HierarchyComponentGroupResultRequestDto : OptionalPagedAndSortedResultRequestDto
    {
        public string? NameContains { get; set; }
        public bool? IsActive { get; set; }
    }
}
