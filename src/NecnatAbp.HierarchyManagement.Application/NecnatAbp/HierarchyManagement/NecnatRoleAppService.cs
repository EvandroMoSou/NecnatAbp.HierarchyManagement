using NecnatAbp.AppServices;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace NecnatAbp.HierarchyManagement
{
    public class NecnatRoleAppService :
        CrudsAppService<
            IdentityRole,
            IdentityRoleDto,
            Guid,
            PagedAndSortedResultRequestDto,
            IdentityRoleDto,
            NecnatRoleResultRequestDto>,
        INecnatRoleAppService
    {
        public NecnatRoleAppService(INecnatRoleRepository repository) : base(repository)
        {
            GetPolicyName = IdentityPermissions.Roles.Default;
            GetListPolicyName = IdentityPermissions.Roles.Default;
        }

        protected override async Task<IQueryable<IdentityRole>> CreateFilteredQuerySearchAsync(NecnatRoleResultRequestDto input)
        {
            var q = await Repository.GetQueryableAsync();

            if (!string.IsNullOrWhiteSpace(input.GenericSearch))
            {
                input.NameContains = input.GenericSearch;
            }

            if (!string.IsNullOrWhiteSpace(input.NameContains))
            {
                if (input.NameContains.Length > IdentityRoleConsts.MaxNameLength)
                    throw new OverflowException($"[NameContains] MaxNameLength: {IdentityRoleConsts.MaxNameLength}");

                q = q.Where(x => x.Name.Contains(input.NameContains));
            }

            return q;
        }

        [RemoteService(false)]
        public override Task<PagedResultDto<IdentityRoleDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return base.GetListAsync(input);
        }

        [RemoteService(false)]
        public override Task<IdentityRoleDto> CreateAsync(IdentityRoleDto input)
        {
            return base.CreateAsync(input);
        }

        [RemoteService(false)]
        public override Task<IdentityRoleDto> UpdateAsync(Guid id, IdentityRoleDto input)
        {
            return base.UpdateAsync(id, input);
        }

        [RemoteService(false)]
        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }
    }
}
