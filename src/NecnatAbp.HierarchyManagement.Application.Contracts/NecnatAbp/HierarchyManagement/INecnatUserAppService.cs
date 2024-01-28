using NecnatAbp.AppServices;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace NecnatAbp.HierarchyManagement
{
    public interface INecnatUserAppService :
        ICrudsAppService<
            IdentityUserDto,
            Guid,
            PagedAndSortedResultRequestDto,
            IdentityUserDto,
            NecnatUserResultRequestDto>,
        IGetAndSearchAppService<IdentityUserDto, Guid, NecnatUserResultRequestDto>
    {

    }
}