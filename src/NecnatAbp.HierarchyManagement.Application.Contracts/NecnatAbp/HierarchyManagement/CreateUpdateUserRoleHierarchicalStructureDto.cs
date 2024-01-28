using NecnatAbp.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

namespace NecnatAbp.HierarchyManagement
{
    public class CreateUpdateUserRoleHierarchicalStructureDto : ConcurrencyDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid RoleId { get; set; }

        public Guid? HierarchicalStructureId { get; set; }
    }
}
