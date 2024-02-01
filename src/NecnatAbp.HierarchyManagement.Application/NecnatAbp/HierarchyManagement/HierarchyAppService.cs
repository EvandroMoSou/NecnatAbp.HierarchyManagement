using NecnatAbp.AppServices;
using NecnatAbp.HierarchyManagement.Permissions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace NecnatAbp.HierarchyManagement
{
    public class HierarchyAppService :
        CrudsAppService<
            Hierarchy,
            HierarchyDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateHierarchyDto,
            HierarchyResultRequestDto>,
        IHierarchyAppService
    {
        public HierarchyAppService(IHierarchyRepository repository) : base(repository)
        {
            GetPolicyName = HierarchyManagementPermissions.Hierarchies.Default;
            GetListPolicyName = HierarchyManagementPermissions.Hierarchies.Default;
            CreatePolicyName = HierarchyManagementPermissions.Hierarchies.Create;
            UpdatePolicyName = HierarchyManagementPermissions.Hierarchies.Update;
            DeletePolicyName = HierarchyManagementPermissions.Hierarchies.Delete;
        }

        protected override async Task<IQueryable<Hierarchy>> CreateFilteredQuerySearchAsync(HierarchyResultRequestDto input)
        {
            var q = await ReadOnlyRepository.GetQueryableAsync();

            if (!string.IsNullOrWhiteSpace(input.NameContains))
            {
                if (input.NameContains.Length > HierarchyConsts.MaxNameLength)
                    throw new OverflowException($"[NameContains] MaxNameLength: {HierarchyConsts.MaxNameLength}");

                q = q.Where(x => x.Name.Contains(input.NameContains));
            }

            if (input.IsActive != null)
                q = q.Where(x => x.IsActive == input.IsActive);

            return q;
        }
    }
}
