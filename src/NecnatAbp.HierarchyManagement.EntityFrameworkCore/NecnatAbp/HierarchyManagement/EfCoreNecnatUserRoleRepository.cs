using NecnatAbp.HierarchyManagement;
using NecnatAbp.HierarchyManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;

namespace NecnatAbp.HierarchyManagement
{
#pragma warning disable CS8613
    public class EfCoreNecnatUserRoleRepository : EfCoreRepository<HierarchyManagementDbContext, IdentityUserRole>, INecnatUserRoleRepository
    {
#pragma warning restore CS8613
        public EfCoreNecnatUserRoleRepository(IDbContextProvider<HierarchyManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
