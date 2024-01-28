using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Users;

namespace NecnatAbp.HierarchyManagement
{
    public class HierarchyAutorizationService : IHierarchyAutorizationService
    {
        readonly ICurrentUser _currentUser;
        readonly IHierarchyAutorizationAppService _hierarchyAutorizationAppService;
        public HierarchyAutorizationModel? HierarchyAutorizationModel { get; set; }

        public HierarchyAutorizationService(
            ICurrentUser currentUser,
            IHierarchyAutorizationAppService hierarchyAutorizationAppService)
        {
            _currentUser = currentUser;
            _hierarchyAutorizationAppService = hierarchyAutorizationAppService;
        }

        public async Task InitializeAsync()
        {
            if (HierarchyAutorizationModel == null || HierarchyAutorizationModel.UserId != _currentUser.Id)
                HierarchyAutorizationModel = await _hierarchyAutorizationAppService.GetHierarchyAuthorizationAsync();
        }

        public bool CheckPermission(string permissionName, int hierarchyComponentType, Guid hierarchyComponentId)
        {
            var lHierarchicalStructureId = GetHierarchicalStructureIdListByPermissionName(permissionName);

            foreach (var iHierarchicalStructureId in lHierarchicalStructureId)
            {
                if (iHierarchicalStructureId == null)
                    return true;

                if (HasHierarchyComponentInHierarchicalStructure((Guid)iHierarchicalStructureId, hierarchyComponentType, hierarchyComponentId))
                    return true;
            }

            return false;
        }

        public List<HamHierarchyComponent> AllowedHierarchyComponentList(string permissionName)
        {
            var lHierarchicalStructureId = GetHierarchicalStructureIdListByPermissionName(permissionName);
            var lHierarchyComponent = new List<HamHierarchyComponent>();

            foreach (var iHierarchicalStructureId in lHierarchicalStructureId)
            {
                if (iHierarchicalStructureId == null)
                {
                    foreach (var iHierarchicalStructure in HierarchyAutorizationModel!.HierarchicalStructureList)
                        if (!lHierarchyComponent.Any(x => x.HierarchyComponentType == iHierarchicalStructure.HierarchyComponentType && x.HierarchyComponentId == iHierarchicalStructure.HierarchyComponentId))
                            lHierarchyComponent.Add(new HamHierarchyComponent { HierarchyComponentType = iHierarchicalStructure.HierarchyComponentType, HierarchyComponentId = iHierarchicalStructure.HierarchyComponentId });

                    return lHierarchyComponent;
                }

                foreach (var iHierarchyComponent in HierarchyAutorizationModel!.HierarchicalStructureList)
                    if (!lHierarchyComponent.Any(x => x.HierarchyComponentType == iHierarchyComponent.HierarchyComponentType && x.HierarchyComponentId == iHierarchyComponent.HierarchyComponentId))
                        lHierarchyComponent.Add(new HamHierarchyComponent { HierarchyComponentType = iHierarchyComponent.HierarchyComponentType, HierarchyComponentId = iHierarchyComponent.HierarchyComponentId });
            }

            return lHierarchyComponent;
        }

        public List<Guid> AllowedHierarchicalStructureIdList(string permissionName)
        {
            var lHierarchicalStructureId = GetHierarchicalStructureIdListByPermissionName(permissionName);
            if (lHierarchicalStructureId.Contains(null))
                return HierarchyAutorizationModel!.HierarchicalStructureList.Select(x => x.Id).ToList();
            else
                return lHierarchicalStructureId.Select(x => (Guid)x!).ToList();
        }

        public bool HasHierarchyComponentInHierarchicalStructure(Guid hierarchicalStructureId, int hierarchyComponentType, Guid hierarchyComponentId)
        {
            var hierarchicalStructure = HierarchyAutorizationModel!.HierarchicalStructureList.Where(x => x.Id == hierarchicalStructureId).FirstOrDefault();

            if (hierarchicalStructure == null)
                return false;

            if (hierarchicalStructure.HierarchyComponentType == hierarchyComponentType && hierarchicalStructure.HierarchyComponentId == hierarchyComponentId)
                return true;

            foreach (var iHierarchicalStructure in HierarchyAutorizationModel.HierarchicalStructureList.Where(x => x.ParentId == hierarchicalStructureId))
                if (HasHierarchyComponentInHierarchicalStructure(iHierarchicalStructure.Id, hierarchyComponentType, hierarchyComponentId))
                    return true;

            return false;
        }

        private List<HamHierarchyComponent> GetHierarchyComponentListByHierarchicalStructureId(Guid hierarchicalStructureId)
        {
            var lHierarchyComponent = new List<HamHierarchyComponent>();

            var hierarchicalStructure = HierarchyAutorizationModel!.HierarchicalStructureList.Where(x => x.Id == hierarchicalStructureId).FirstOrDefault();
            if (hierarchicalStructure == null)
                return lHierarchyComponent;

            lHierarchyComponent.Add(new HamHierarchyComponent { HierarchyComponentType = hierarchicalStructure.HierarchyComponentType, HierarchyComponentId = hierarchicalStructure.HierarchyComponentId });

            foreach (var iHierarchicalStructure in HierarchyAutorizationModel.HierarchicalStructureList.Where(x => x.ParentId == hierarchicalStructureId))
            {
                var lHierarchyComponentChild = GetHierarchyComponentListByHierarchicalStructureId(iHierarchicalStructure.Id);
                foreach (var iHierarchyComponentChild in lHierarchyComponentChild)
                    if (!lHierarchyComponent.Any(x => x.HierarchyComponentType == iHierarchyComponentChild.HierarchyComponentType && x.HierarchyComponentId == iHierarchyComponentChild.HierarchyComponentId))
                        lHierarchyComponent.Add(new HamHierarchyComponent { HierarchyComponentType = iHierarchyComponentChild.HierarchyComponentType, HierarchyComponentId = iHierarchyComponentChild.HierarchyComponentId });
            }

            return lHierarchyComponent;
        }

        public HamHierarchyComponent? GetHierarchyComponentBy(Guid? hierarchicalStructureId)
        {
            if (hierarchicalStructureId == null)
                return null;

            var hierarchicalStructure = HierarchyAutorizationModel!.HierarchicalStructureList.Where(x => x.Id == hierarchicalStructureId).FirstOrDefault();
            if (hierarchicalStructure == null)
                return null;

            return new HamHierarchyComponent { HierarchyComponentType = hierarchicalStructure.HierarchyComponentType, HierarchyComponentId = hierarchicalStructure.HierarchyComponentId };
        }

        private List<Guid?> GetHierarchicalStructureIdListByPermissionName(string permissionName)
        {
            if (HierarchyAutorizationModel == null || HierarchyAutorizationModel.RolePermissionNameList == null || HierarchyAutorizationModel.RoleHierarchicalStructureIdList == null || HierarchyAutorizationModel.HierarchicalStructureList == null)
                return new List<Guid?>();

            var lRoleId = HierarchyAutorizationModel.RolePermissionNameList.Where(x => x.PermissionNameList.Contains(permissionName)).Select(x => x.RoleId);

            var lHierarchicalStructureId = new List<Guid?>();
            foreach (var iRoleHierarchicalStructureId in HierarchyAutorizationModel.RoleHierarchicalStructureIdList.Where(x => lRoleId.Contains(x.RoleId)))
                foreach (var iHierarchicalStructureId in iRoleHierarchicalStructureId.HierarchicalStructureIdList)
                    if (!lHierarchicalStructureId.Contains(iHierarchicalStructureId))
                        lHierarchicalStructureId.Add(iHierarchicalStructureId);

            return lHierarchicalStructureId;
        }
    }
}
