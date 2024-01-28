using NecnatAbp.HierarchyManagement;
using NecnatAbp.HierarchyManagement.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;

namespace NecnatAbp.HierarchyManagement
{
#pragma warning disable CS8613
    public class EfCoreNecnatRoleRepository : EfCoreRepository<HierarchyManagementDbContext, IdentityRole, Guid>, INecnatRoleRepository
    {
#pragma warning restore CS8613
        public EfCoreNecnatRoleRepository(IDbContextProvider<HierarchyManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
