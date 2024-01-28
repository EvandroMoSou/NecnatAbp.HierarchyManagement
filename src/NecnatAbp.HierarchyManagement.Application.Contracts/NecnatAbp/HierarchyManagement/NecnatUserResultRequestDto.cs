using NecnatAbp.Dtos;

namespace NecnatAbp.HierarchyManagement
{
    public class NecnatUserResultRequestDto : AutocompleteResultRequestDto
    {
        public string? UserName { get; set; }
        public string? NameContains { get; set; }
    }
}
