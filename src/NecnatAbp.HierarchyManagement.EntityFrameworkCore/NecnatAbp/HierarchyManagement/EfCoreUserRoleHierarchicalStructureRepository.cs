using NecnatAbp.HierarchyManagement;
using NecnatAbp.HierarchyManagement.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace NecnatAbp.HierarchyManagement
{
#pragma warning disable CS8613
    public class EfCoreUserRoleHierarchicalStructureRepository : EfCoreRepository<HierarchyManagementDbContext, UserRoleHierarchicalStructure, Guid>, IUserRoleHierarchicalStructureRepository
    {
#pragma warning restore CS8613
        public EfCoreUserRoleHierarchicalStructureRepository(IDbContextProvider<HierarchyManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
