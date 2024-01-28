using NecnatAbp.AppServices;
using NecnatAbp.HierarchyManagement.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace NecnatAbp.HierarchyManagement
{
    public class HierarchicalStructureAppService :
        CrudsAppService<
            HierarchicalStructure,
            HierarchicalStructureDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateHierarchicalStructureDto,
            HierarchicalStructureResultRequestDto>,
        IHierarchicalStructureAppService
    {
        public HierarchicalStructureAppService(IHierarchicalStructureRepository repository) : base(repository)
        {
            GetPolicyName = HierarchyManagementPermissions.HierarchicalStructure.Default;
            GetListPolicyName = HierarchyManagementPermissions.HierarchicalStructure.Default;
            CreatePolicyName = HierarchyManagementPermissions.HierarchicalStructure.Create;
            DeletePolicyName = HierarchyManagementPermissions.HierarchicalStructure.Delete;
        }

        protected override async Task<IQueryable<HierarchicalStructure>> CreateFilteredQuerySearchAsync(HierarchicalStructureResultRequestDto input)
        {
            var q = await ReadOnlyRepository.GetQueryableAsync();

            if (input.UseParentId)
                q = q.Where(x => x.ParentId == input.ParentId);

            if (input.HierarchyId != null)
                q = q.Where(x => x.HierarchyId == input.HierarchyId);

            return q;
        }

        [RemoteService(false)]
        public override Task<HierarchicalStructureDto> UpdateAsync(Guid id, CreateUpdateHierarchicalStructureDto input)
        {
            return base.UpdateAsync(id, input);
        }

        public virtual Task<List<HierarchyComponentDto>> ListHierarchyComponentAsync()
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<HierarchyComponentTypeDto>> ListHierarchyComponentTypeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
