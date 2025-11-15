using RoslynHelpers.LocalizableResource;
using RoslynHelpers.Tests.ResourceResolving.TestData;
using RoslynHelpers.Tests.LocalizableResource.TestData;


namespace RoslynHelpers.Tests.ResourceResolving;

public class ResourceTests
{
    public static TheoryData<IResource, string> ResourceToResourceClassMap => ResourceResolvingTestData.ResourceToClassMemberMappingData;

    [Theory]
    [MemberData(nameof(ResourceToResourceClassMap))]
    public void Title_YiedsSameResultAs_NameOfKeyword(IResource resource, string sourceFileMember)
    {
        var resourceValue = resource.GetFrom<TestResources>();
        Assert.Equal(sourceFileMember, resourceValue);
    }
}