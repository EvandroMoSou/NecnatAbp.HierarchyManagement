using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace NecnatAbp.HierarchyManagement.Pages;

public class IndexModel : HierarchyManagementPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
