using NecnatAbp.AppServices;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace NecnatAbp.HierarchyManagement
{
    public class NecnatUserAppService :
        CrudsAppService<
            IdentityUser,
            IdentityUserDto,
            Guid,
            PagedAndSortedResultRequestDto,
            IdentityUserDto,
            NecnatUserResultRequestDto>,
        INecnatUserAppService
    {
        public NecnatUserAppService(INecnatUserRepository repository) : base(repository)
        {
            GetPolicyName = IdentityPermissions.Users.Default;
            GetListPolicyName = IdentityPermissions.Users.Default;
        }

        protected override async Task<IQueryable<IdentityUser>> CreateFilteredQuerySearchAsync(NecnatUserResultRequestDto input)
        {
            var q = await Repository.GetQueryableAsync();

            if (!string.IsNullOrWhiteSpace(input.GenericSearch))
            {
                q = q.Where(x => x.UserName == input.GenericSearch || x.Name.Contains(input.GenericSearch));
            }

            if (!string.IsNullOrWhiteSpace(input.UserName))
            {
                if (input.UserName.Length > IdentityUserConsts.MaxUserNameLength)
                    throw new OverflowException($"[UserName] MaxUserNameLength: {IdentityUserConsts.MaxUserNameLength}");

                q = q.Where(x => x.UserName == input.UserName);
            }

            if (!string.IsNullOrWhiteSpace(input.NameContains))
            {
                if (input.NameContains.Length > IdentityUserConsts.MaxNameLength)
                    throw new OverflowException($"[NameContains] MaxNameLength: {IdentityUserConsts.MaxNameLength}");

                q = q.Where(x => x.Name.Contains(input.NameContains));
            }

            return q;
        }

        [RemoteService(false)]
        public override Task<PagedResultDto<IdentityUserDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return base.GetListAsync(input);
        }

        [RemoteService(false)]
        public override Task<IdentityUserDto> CreateAsync(IdentityUserDto input)
        {
            return base.CreateAsync(input);
        }

        [RemoteService(false)]
        public override Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserDto input)
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
