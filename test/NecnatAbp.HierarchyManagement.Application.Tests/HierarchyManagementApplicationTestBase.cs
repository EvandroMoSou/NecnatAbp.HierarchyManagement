using Volo.Abp.Modularity;

namespace NecnatAbp.HierarchyManagement;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class HierarchyManagementApplicationTestBase<TStartupModule> : HierarchyManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
