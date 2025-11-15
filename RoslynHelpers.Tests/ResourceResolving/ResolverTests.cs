using RoslynHelpers._Internals.ResourceResolving;
using RoslynHelpers.Tests.ResourceResolving.TestData;
using RoslynHelpers.Tests.LocalizableResource.TestData;


namespace RoslynHelpers.Tests.ResourceResolving;

public class ResolverTests
{
    public static TheoryData<string> ResourceIdentifierCollection => ResourceResolvingTestData.ResourceIdentifierCollectionData;
    public static TheoryData<string, string> ResourceIdentifierToClassMemberMap => ResourceResolvingTestData.ResourceIdentifierToClassMemberMappingData;


    [Fact]
    internal void ResourceManagerResolver_YieldsSameResultAs_ClassMember()
    {
        var resolved = AnalyzerResourceManagerResolver<TestResources>.Get();
        var classProperty = TestResources.ResourceManager;

        Assert.Equal(resolved, classProperty);
    }

    [Theory]
    [MemberData(nameof(ResourceIdentifierCollection))]
    internal void ReturnsString(string resourceIdentifier)
    {
        var resolver = ResolverBuilder.Build<TestResources>(resourceIdentifier);
        var retValue = resolver();

        Assert.NotNull(retValue);
        Assert.IsType<string>(retValue);
    }

    [Theory]
    [MemberData(nameof(ResourceIdentifierToClassMemberMap))]
    internal void YieldsSameResult_As_NameOfKeyword(string identifier, string nameOfClassMember)
    {
        var resolver = ResolverBuilder.Build<TestResources>(identifier);
        var resolverRetValue = resolver();

        Assert.Equal(resolverRetValue, nameOfClassMember);
    }
}