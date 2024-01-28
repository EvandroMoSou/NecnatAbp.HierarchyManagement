using AutoMapper;

namespace NecnatAbp.HierarchyManagement;

public class HierarchyManagementApplicationAutoMapperProfile : Profile
{
    public HierarchyManagementApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Hierarchy, HierarchyDto>();
        CreateMap<CreateUpdateHierarchyDto, Hierarchy>();

        CreateMap<HierarchyComponentGroup, HierarchyComponentGroupDto>();
        CreateMap<CreateUpdateHierarchyComponentGroupDto, HierarchyComponentGroup>();

        CreateMap<HierarchicalStructure, HierarchicalStructureDto>();
        CreateMap<CreateUpdateHierarchicalStructureDto, HierarchicalStructure>();

        CreateMap<UserRoleHierarchicalStructure, UserRoleHierarchicalStructureDto>();
        CreateMap<CreateUpdateUserRoleHierarchicalStructureDto, UserRoleHierarchicalStructure>();

        CreateMap<HierarchyComponent, HierarchyComponent>();
    }
}
