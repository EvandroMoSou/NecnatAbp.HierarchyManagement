using Volo.Abp.Modularity;

namespace NecnatAbp.HierarchyManagement;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class HierarchyManagementDomainTestBase<TStartupModule> : HierarchyManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
