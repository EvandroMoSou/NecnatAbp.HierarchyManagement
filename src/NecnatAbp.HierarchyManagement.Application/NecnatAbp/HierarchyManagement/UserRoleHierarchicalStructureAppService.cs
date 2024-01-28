using Microsoft.AspNetCore.Identity;
using NecnatAbp.AppServices;
using NecnatAbp.HierarchyManagement.Permissions;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace NecnatAbp.HierarchyManagement
{
    public class UserRoleHierarchicalStructureAppService :
        CrudsAppService<
            UserRoleHierarchicalStructure,
            UserRoleHierarchicalStructureDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateUserRoleHierarchicalStructureDto,
            UserRoleHierarchicalStructureResultRequestDto>,
        IUserRoleHierarchicalStructureAppService
    {
        protected IHierarchyAuthRepository HierarchyAuthRepository => LazyServiceProvider.LazyGetRequiredService<IHierarchyAuthRepository>();
        protected IdentityUserManager UserManager { get; }
        protected IIdentityRoleRepository RoleRepository { get; }
        protected INecnatUserRoleRepository UserRoleRepository { get; }
        protected IHierarchicalStructureRepository HierarchicalStructureRepository { get; }

        public UserRoleHierarchicalStructureAppService(
            IUserRoleHierarchicalStructureRepository repository,
            IdentityUserManager userManager,
            IIdentityRoleRepository roleRepository,
            INecnatUserRoleRepository userRoleRepository,
            IHierarchicalStructureRepository hierarchicalStructureRepository) : base(repository)
        {
            UserManager = userManager;
            RoleRepository = roleRepository;
            UserRoleRepository = userRoleRepository;
            HierarchicalStructureRepository = hierarchicalStructureRepository;

            GetPolicyName = HierarchyManagementPermissions.UserRoleHierarchicalStructure.Default;
            GetListPolicyName = HierarchyManagementPermissions.UserRoleHierarchicalStructure.Default;
            CreatePolicyName = HierarchyManagementPermissions.UserRoleHierarchicalStructure.Create;
            UpdatePolicyName = HierarchyManagementPermissions.UserRoleHierarchicalStructure.Update;
            DeletePolicyName = HierarchyManagementPermissions.UserRoleHierarchicalStructure.Delete;
        }

        protected override async Task<IQueryable<UserRoleHierarchicalStructure>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
        {
            var q = await base.CreateFilteredQueryAsync(input);

            var lHierarchicalStructureId = await HierarchyAuthRepository.SearchHierarchicalStructureIdAsync((Guid)CurrentUser.Id!, HierarchyManagementPermissions.UserRoleHierarchicalStructure.Default);
            q = q.Where(x => lHierarchicalStructureId.Contains(x.HierarchicalStructureId));

            return q;
        }

        protected override async Task<IQueryable<UserRoleHierarchicalStructure>> CreateFilteredQuerySearchAsync(UserRoleHierarchicalStructureResultRequestDto input)
        {
            var q = await Repository.GetQueryableAsync();

            if (input.UserId != null)
                q = q.Where(x => x.UserId == input.UserId);

            if (input.RoleId != null)
                q = q.Where(x => x.RoleId == input.RoleId);

            if (input.HierarchicalStructureId != null)
                q = q.Where(x => x.HierarchicalStructureId == input.HierarchicalStructureId);

            var lHierarchicalStructureId = await HierarchyAuthRepository.SearchHierarchicalStructureIdAsync((Guid)CurrentUser.Id!, HierarchyManagementPermissions.UserRoleHierarchicalStructure.Default);
            q = q.Where(x => lHierarchicalStructureId.Contains(x.HierarchicalStructureId));

            return q;
        }

        public override async Task<UserRoleHierarchicalStructureDto> GetAsync(Guid id)
        {
            var e = await base.GetAsync(id);

            await HierarchyAuthRepository.CheckByHierarchicalStructureIdAsync((Guid)CurrentUser.Id!, HierarchyManagementPermissions.UserRoleHierarchicalStructure.Default, e.HierarchicalStructureId);

            return e;
        }

        public override async Task<PagedResultDto<UserRoleHierarchicalStructureDto>> SearchAsync(UserRoleHierarchicalStructureResultRequestDto input)
        {
            var pagedResultDto = await base.SearchAsync(input);

            foreach (var iItem in pagedResultDto.Items)
            {
                if (iItem.UserId != null)
                    iItem.UserUserName = (await UserManager.FindByIdAsync(iItem.UserId.ToString()!))?.UserName;
            }

            return pagedResultDto;
        }

        public override async Task<UserRoleHierarchicalStructureDto> CreateAsync(CreateUpdateUserRoleHierarchicalStructureDto input)
        {
            await HierarchyAuthRepository.CheckByHierarchicalStructureIdAsync((Guid)CurrentUser.Id!, HierarchyManagementPermissions.UserRoleHierarchicalStructure.Create, input.HierarchicalStructureId);

            var lUserRole = await UserRoleRepository.GetListAsync(x => x.UserId == input.UserId && x.RoleId == input.RoleId);
            if (!lUserRole.Any())
            {
                var user = await UserManager.GetByIdAsync(input.UserId);
                var role = await RoleRepository.GetAsync(input.RoleId);
                var lRole = await UserManager.GetRolesAsync(user);
                lRole.Add(role.Name);
                (await UserManager.SetRolesAsync(user, lRole)).CheckErrors();
            }

            return await base.CreateAsync(input);
        }

        public override async Task<UserRoleHierarchicalStructureDto> UpdateAsync(Guid id, CreateUpdateUserRoleHierarchicalStructureDto input)
        {
            var e = await Repository.GetAsync(id);
            await HierarchyAuthRepository.CheckByHierarchicalStructureIdAsync((Guid)CurrentUser.Id!, HierarchyManagementPermissions.UserRoleHierarchicalStructure.Update, e.HierarchicalStructureId);
            if (e.HierarchicalStructureId != input.HierarchicalStructureId)
                await HierarchyAuthRepository.CheckByHierarchicalStructureIdAsync((Guid)CurrentUser.Id!, HierarchyManagementPermissions.UserRoleHierarchicalStructure.Update, input.HierarchicalStructureId);

            if (e.RoleId != input.RoleId)
            {
                var user = await UserManager.GetByIdAsync(e.UserId);
                var lRole = await UserManager.GetRolesAsync(user);

                var lUserRoleDelete = await UserRoleRepository.GetListAsync(x => x.UserId == e.UserId && x.RoleId == e.RoleId);
                if (lUserRoleDelete.Count() == 1)
                {
                    var role = await RoleRepository.GetAsync(e.RoleId);
                    lRole.Remove(role.Name);
                }

                var lUserRoleInsert = await UserRoleRepository.GetListAsync(x => x.UserId == input.UserId && x.RoleId == input.RoleId);
                if (!lUserRoleInsert.Any())
                {
                    var role = await RoleRepository.GetAsync(input.RoleId);
                    lRole.Add(role.Name);
                }

                (await UserManager.SetRolesAsync(user, lRole)).CheckErrors();
            }

            return await base.UpdateAsync(id, input);
        }

        public override async Task DeleteAsync(Guid id)
        {
            var e = await Repository.GetAsync(id);
            await HierarchyAuthRepository.CheckByHierarchicalStructureIdAsync((Guid)CurrentUser.Id!, HierarchyManagementPermissions.UserRoleHierarchicalStructure.Delete, e.HierarchicalStructureId);

            var lUserRole = await UserRoleRepository.GetListAsync(x => x.UserId == e.UserId && x.RoleId == e.RoleId);
            if (lUserRole.Count() == 1)
            {
                var user = await UserManager.GetByIdAsync(e.UserId);
                var role = await RoleRepository.GetAsync(e.RoleId);
                var lRole = await UserManager.GetRolesAsync(user);
                lRole.Remove(role.Name);
                (await UserManager.SetRolesAsync(user, lRole)).CheckErrors();
            }

            await base.DeleteAsync(id);
        }
    }
}
