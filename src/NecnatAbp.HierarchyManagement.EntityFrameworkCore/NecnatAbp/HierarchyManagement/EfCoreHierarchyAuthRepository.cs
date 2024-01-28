using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using NecnatAbp.HierarchyManagement;
using NecnatAbp.HierarchyManagement.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Caching;

namespace NecnatAbp.HierarchyManagement
{
    public class EfCoreHierarchyAuthRepository : IHierarchyAuthRepository
    {
        readonly IDistributedCache<PermissionRoleIdCacheItem> _permissionRoleIdCache;
        //TODO Apagar
        //readonly IDistributedCache<RolePermissionNameCacheItem> _rolePermissionNameCacheItemCache;
        //readonly IDistributedCache<HierarchicalStructureHierarchyComponentCacheItem> _hierarchicalStructureHierarchyComponentCacheItemCache;

        protected HierarchyManagementDbContext DbContext { get; }

        public bool? IsChangeTrackingEnabled => throw new NotImplementedException();

        public EfCoreHierarchyAuthRepository(
            IDistributedCache<PermissionRoleIdCacheItem> permissionRoleIdCache,
            IDistributedCache<RolePermissionNameCacheItem> rolePermissionNameCacheItemCache,
            IDistributedCache<HierarchicalStructureHierarchyComponentCacheItem> hierarchicalStructureHierarchyComponentCacheItemCache,
            HierarchyManagementDbContext dbContext)
        {
            _permissionRoleIdCache = permissionRoleIdCache;
            //_rolePermissionNameCacheItemCache = rolePermissionNameCacheItemCache;
            //_hierarchicalStructureHierarchyComponentCacheItemCache = hierarchicalStructureHierarchyComponentCacheItemCache;
            DbContext = dbContext;
        }

        public async Task CheckByHierarchicalStructureIdAsync(Guid userId, string permissionName, Guid? hierarchicalStructureId)
        {
            var lHierarchicalStructureId = await GetHierarchicalStructureIdAsync(userId, permissionName);
            if (!lHierarchicalStructureId.Contains(hierarchicalStructureId))
                throw new AccessViolationException($"User: {userId} not have permission: {permissionName} in hierarchical structure: {hierarchicalStructureId}.");
        }

        public async Task<List<Guid?>> SearchHierarchicalStructureIdAsync(Guid userId, string permissionName)
        {
            return await GetHierarchicalStructureIdAsync(userId, permissionName);
        }

        protected async Task<List<Guid?>> GetHierarchicalStructureIdAsync(Guid userId, string permissionName)
        {
            var lRoleId = await GetPermissionRoleIdAsync(permissionName);
            if (lRoleId == null || lRoleId.Count < 1)
                throw new AccessViolationException($"User: {userId} not have permission: {permissionName}.");

            return await DbContext.UserRoleHierarchicalStructures.Where(x => x.UserId == userId && lRoleId.Contains(x.RoleId)).Select(x => x.HierarchicalStructureId).ToListAsync();
        }

        protected async Task<List<Guid>?> GetPermissionRoleIdAsync(string permissionName)
        {
            var cache = await _permissionRoleIdCache.GetOrAddAsync(
                permissionName,
                async () => await GetPermissionRoleIdFromDatabaseAsync(permissionName),
                () => new DistributedCacheEntryOptions { AbsoluteExpiration = DateTimeOffset.Now.AddHours(1) }
            );

            return cache?.RoleIdList;
        }

        private async Task<PermissionRoleIdCacheItem> GetPermissionRoleIdFromDatabaseAsync(string permissionName)
        {
            var lRoleName = DbContext.PermissionGrant.Where(x => x.ProviderName == "R" && x.Name == permissionName).Select(x => x.ProviderKey);
            var lRoleId = await DbContext.Roles.Where(x => lRoleName.Contains(x.Name)).Select(x => x.Id).ToListAsync();

            return new PermissionRoleIdCacheItem { RoleIdList = lRoleId };
        }

        //protected async Task<List<string>?> GetRolePermissionNameAsync(Guid roleId)
        //{
        //    var cache = await _rolePermissionNameCacheItemCache.GetOrAddAsync(
        //        roleId.ToString(),
        //        async () => await GetRolePermissionNameFromDatabaseAsync(roleId),
        //        () => new DistributedCacheEntryOptions { AbsoluteExpiration = DateTimeOffset.Now.AddHours(1) }
        //    );

        //    return cache?.PermissionNameList;
        //}

        //private async Task<RolePermissionNameCacheItem> GetRolePermissionNameFromDatabaseAsync(Guid roleId)
        //{
        //    var role = DbContext.Roles.Where(x => x.Id == roleId).FirstOrDefault();
        //    if (role == null)
        //        return new RolePermissionNameCacheItem { PermissionNameList = new List<string>() };

        //    var lPermissionName = await DbContext.PermissionGrant.Where(x => x.ProviderName == "R" && x.ProviderKey == role.Name).Select(x => x.Name).ToListAsync();
        //    return new RolePermissionNameCacheItem { PermissionNameList = lPermissionName };
        //}

        //protected async Task<List<HierarchyComponent>?> GetHierarchicalStructureHierarchyComponentAsync(Guid hierarchicalStructureId)
        //{
        //    var cache = await _hierarchicalStructureHierarchyComponentCacheItemCache.GetOrAddAsync(
        //        hierarchicalStructureId.ToString(),
        //        async () => await GetHierarchicalStructureHierarchyComponentFromDatabaseAsync(hierarchicalStructureId),
        //        () => new DistributedCacheEntryOptions { AbsoluteExpiration = DateTimeOffset.Now.AddHours(1) }
        //    );

        //    return cache?.HierarchyComponentList;
        //}

        //private async Task<HierarchicalStructureHierarchyComponentCacheItem> GetHierarchicalStructureHierarchyComponentFromDatabaseAsync(Guid hierarchicalStructureId)
        //{
        //    var role = DbContext.Roles.Where(x => x.Id == roleId).FirstOrDefault();
        //    if (role == null)
        //        return new HierarchicalStructureHierarchyComponentCacheItem { PermissionNameList = new List<string>() };

        //    var lPermissionName = await DbContext.PermissionGrant.Where(x => x.ProviderName == "R" && x.ProviderKey == role.Name).Select(x => x.Name).ToListAsync();
        //    return new HierarchicalStructureHierarchyComponentCacheItem { PermissionNameList = lPermissionName };
        //}
    }
}
