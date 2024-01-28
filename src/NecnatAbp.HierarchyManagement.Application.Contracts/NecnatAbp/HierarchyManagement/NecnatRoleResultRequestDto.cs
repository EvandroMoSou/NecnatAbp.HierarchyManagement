using NecnatAbp.Dtos;

namespace NecnatAbp.HierarchyManagement
{
    public class NecnatRoleResultRequestDto : AutocompleteResultRequestDto
    {
        public string? NameContains { get; set; }
    }
}
