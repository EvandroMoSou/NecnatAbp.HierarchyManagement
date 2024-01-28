using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace NecnatAbp.HierarchyManagement
{
    public interface IHierarchyAutorizationAppService : IApplicationService, IRemoteService
    {
        Task<HierarchyAutorizationModel> GetHierarchyAuthorizationAsync();
    }
}
