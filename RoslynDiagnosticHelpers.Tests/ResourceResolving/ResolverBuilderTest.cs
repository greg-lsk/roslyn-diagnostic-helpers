using RoslynHelpers._Internals.ResourceResolving;
using RoslynHelpers.Tests.ResourceResolving.TestData;
using RoslynHelpers.Tests.LocalizableResource.TestData;


namespace RoslynHelpers.Tests.ResourceResolving;

public class ResolverBuilderTest
{
    public static TheoryData<string> ResourceIdentifierCollection => ResourceResolvingTestData.ResourceIdentifierCollectionData;

    [Theory]
    [MemberData(nameof(ResourceIdentifierCollection))]
    internal void Creates_ResolverDelegate(string resourceIdentifier)
    {
        var resolver = ResolverBuilder.Build<TestResources>(resourceIdentifier);

        Assert.NotNull(resolver);
        Assert.IsType<Resolver<TestResources>>(resolver);
    }
}