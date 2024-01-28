using NecnatAbp.HierarchyManagement.Samples;
using Xunit;

namespace NecnatAbp.HierarchyManagement.MongoDB.Domains;

[Collection(MongoTestCollection.Name)]
public class MongoDBSampleDomain_Tests : SampleManager_Tests<HierarchyManagementMongoDbTestModule>
{

}
