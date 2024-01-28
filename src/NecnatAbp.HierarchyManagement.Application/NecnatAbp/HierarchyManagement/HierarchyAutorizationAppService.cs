using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;

namespace NecnatAbp.HierarchyManagement
{
    [Authorize]
    public class HierarchyAutorizationAppService : ApplicationService, IHierarchyAutorizationAppService
    {
        protected IUserRoleHierarchicalStructureRepository UserRoleHierarchicalStructureRepository { get; }
        protected IHierarchicalStructureRepository HierarchicalStructureRepository { get; }
        protected IIdentityRoleRepository IdentityRoleRepository { get; }
        protected IPermissionGrantRepository PermissionGrantRepository { get; }

        public HierarchyAutorizationAppService(
            IUserRoleHierarchicalStructureRepository userRoleHierarchicalStructureRepository,
            IHierarchicalStructureRepository hierarchicalStructureRepository,
            IIdentityRoleRepository identityRoleRepository,
            IPermissionGrantRepository permissionGrantRepository)
        {
            UserRoleHierarchicalStructureRepository = userRoleHierarchicalStructureRepository;
            HierarchicalStructureRepository = hierarchicalStructureRepository;
            IdentityRoleRepository = identityRoleRepository;
            PermissionGrantRepository = permissionGrantRepository;
        }

        public async Task<HierarchyAutorizationModel> GetHierarchyAuthorizationAsync()
        {
            var ha = new HierarchyAutorizationModel();
            ha.UserId = (Guid)CurrentUser.Id!;

            var lUserRoleHierarchicalStructure = await UserRoleHierarchicalStructureRepository.GetListAsync(x => x.UserId == CurrentUser.Id);
            foreach (var iUserRoleHierarchicalStructure in lUserRoleHierarchicalStructure)
            {
                //RolePermissionNameList
                var rolePermissionName = ha.RolePermissionNameList.Where(x => x.RoleId == iUserRoleHierarchicalStructure.RoleId).FirstOrDefault();
                if (rolePermissionName == null)
                {
                    rolePermissionName = new HamRolePermissionName { RoleId = iUserRoleHierarchicalStructure.RoleId };
                    var role = await IdentityRoleRepository.GetAsync(iUserRoleHierarchicalStructure.RoleId);
                    var lPermissionGrant = await PermissionGrantRepository.GetListAsync("R", role.Name);
                    foreach (var iPermissionGrant in lPermissionGrant)
                        rolePermissionName.PermissionNameList.Add(iPermissionGrant.Name);

                    ha.RolePermissionNameList.Add(rolePermissionName);
                }

                //RoleHierarchicalStructureIdList
                var insertRoleHierarchicalStructureId = false;
                var roleHierarchicalStructureId = ha.RoleHierarchicalStructureIdList.Where(x => x.RoleId == iUserRoleHierarchicalStructure.RoleId).FirstOrDefault();
                if (roleHierarchicalStructureId == null)
                {
                    roleHierarchicalStructureId = new HamRoleHierarchicalStructureId { RoleId = iUserRoleHierarchicalStructure.RoleId };
                    insertRoleHierarchicalStructureId = true;
                }

                if (!roleHierarchicalStructureId.HierarchicalStructureIdList.Contains(iUserRoleHierarchicalStructure.HierarchicalStructureId))
                    roleHierarchicalStructureId.HierarchicalStructureIdList.Add(iUserRoleHierarchicalStructure.HierarchicalStructureId);

                if (insertRoleHierarchicalStructureId)
                    ha.RoleHierarchicalStructureIdList.Add(roleHierarchicalStructureId);
            }

            //HierarchicalStructureList
            var lHierarchicalStructure = await HierarchicalStructureRepository.GetListAsync();
            foreach (var iHierarchicalStructure in lHierarchicalStructure)
                ha.HierarchicalStructureList.Add(new HamHierarchicalStructure
                {
                    Id = iHierarchicalStructure.Id,
                    ParentId = iHierarchicalStructure.ParentId,
                    HierarchyId = iHierarchicalStructure.HierarchyId,
                    HierarchyComponentType = iHierarchicalStructure.HierarchyComponentType,
                    HierarchyComponentId = iHierarchicalStructure.HierarchyComponentId,
                });

            return ha;
        }
    }
}
