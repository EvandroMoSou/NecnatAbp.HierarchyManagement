using NecnatAbp.AppServices;
using NecnatAbp.HierarchyManagement.Permissions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace NecnatAbp.HierarchyManagement
{
    public class HierarchyComponentGroupAppService :
        CrudsAppService<
            HierarchyComponentGroup,
            HierarchyComponentGroupDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateHierarchyComponentGroupDto,
            HierarchyComponentGroupResultRequestDto>,
        IHierarchyComponentGroupAppService
    {
        public HierarchyComponentGroupAppService(IHierarchyComponentGroupRepository repository) : base(repository)
        {
            GetPolicyName = HierarchyManagementPermissions.HierarchyComponentGroups.Default;
            GetListPolicyName = HierarchyManagementPermissions.HierarchyComponentGroups.Default;
            CreatePolicyName = HierarchyManagementPermissions.HierarchyComponentGroups.Create;
            UpdatePolicyName = HierarchyManagementPermissions.HierarchyComponentGroups.Update;
            DeletePolicyName = HierarchyManagementPermissions.HierarchyComponentGroups.Delete;
        }

        protected override async Task<IQueryable<HierarchyComponentGroup>> CreateFilteredQuerySearchAsync(HierarchyComponentGroupResultRequestDto input)
        {
            var q = await ReadOnlyRepository.GetQueryableAsync();

            if (!string.IsNullOrWhiteSpace(input.NameContains))
            {
                if (input.NameContains.Length > HierarchyComponentGroupConsts.MaxNameLength)
                    throw new OverflowException($"[NameContains] MaxNameLength: {HierarchyComponentGroupConsts.MaxNameLength}");

                q = q.Where(x => x.Name.Contains(input.NameContains));
            }

            if (input.IsActive != null)
                q = q.Where(x => x.IsActive == input.IsActive);

            return q;
        }
    }
}
