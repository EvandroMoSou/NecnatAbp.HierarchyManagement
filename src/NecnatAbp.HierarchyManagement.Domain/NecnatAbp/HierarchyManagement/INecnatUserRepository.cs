using System;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace NecnatAbp.HierarchyManagement
{
    public interface INecnatUserRepository : IRepository<IdentityUser, Guid>
    {

    }
}
