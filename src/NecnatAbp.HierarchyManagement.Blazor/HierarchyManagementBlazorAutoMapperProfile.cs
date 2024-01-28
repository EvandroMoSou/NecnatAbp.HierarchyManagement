using AutoMapper;
using NecnatAbp.HierarchyManagement;

namespace NecnatAbp.HierarchyManagement.Blazor;

public class HierarchyManagementBlazorAutoMapperProfile : Profile
{
    public HierarchyManagementBlazorAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<HierarchyDto, CreateUpdateHierarchyDto>();

        CreateMap<HierarchyComponentGroupDto, CreateUpdateHierarchyComponentGroupDto>();

        CreateMap<HierarchicalStructureDto, CreateUpdateHierarchicalStructureDto>();

        CreateMap<UserRoleHierarchicalStructureDto, CreateUpdateUserRoleHierarchicalStructureDto>();
    }
}
