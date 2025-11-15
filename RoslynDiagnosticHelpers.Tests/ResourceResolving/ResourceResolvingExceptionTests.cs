using RoslynHelpers.Exceptions;
using RoslynHelpers._Internals.ResourceResolving;
using RoslynHelpers.Tests.LocalizableResource.TestData;
using static RoslynHelpers.Tests.ResourceResolving.TestData.ResourceResolvingExceptionsTestData;


namespace RoslynHelpers.Tests.ResourceResolving;

public class ResourceResolvingExceptionTests
{
    [Fact]
    public void Static_ResolveBuilders_FromExistingSource_ThrowWhen_BuildMethodIsCalled_WithInvalidMember()
    {
        Assert.Throws<InvalidResourceResolutionException<TestResources>>(() => ResolverBuilder.Build<TestResources>(NonExistantResource));
    }


    [Fact]
    public void Static_Resolvers_OnExistingSource_ThrowOn_FirstAccessToAnInvalidMember()
    {
        Assert.Throws<TypeInitializationException>(() => NonExistantResourceResolver<TestResources>.Get);
    }
}