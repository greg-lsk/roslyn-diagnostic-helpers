using RoslynHelpers.LocalizableResource;
using RoslynHelpers.Tests.ResourceResolving.TestData;
using RoslynHelpers.Tests.LocalizableResource.TestData;


namespace RoslynHelpers.Tests.ResourceResolving;

public class ResourceTests
{
    public static TheoryData<IResource, string> IResourceToSourceResourceMember 
        => ResourceResolvingTestData.IResourceToSourceResourceMember_ValidMap;

    [Theory]
    [MemberData(nameof(IResourceToSourceResourceMember))]
    internal void IResource_CorrectlyMapsTo_SourceResourceMember(IResource resource, string expectedValue)
    {
        var resourceValue = resource.GetFrom<TestResources>();
        Assert.Equal(expectedValue, resourceValue);
    }
}