using System.Resources;
using RoslynHelpers.Exceptions;
using RoslynHelpers._Internals.ResourceResolving;
using RoslynHelpers.Tests.LocalizableResource.TestData;


namespace RoslynHelpers.Tests.ResourceResolving.TestData;

internal static class ResourceResolvingExceptionsTestData
{
    internal static string InvalidResourceManagerName => "AnalyzerManaggger";
    internal static TheoryData<Action, Type> InvalidResolverBuilderInvocation_ExpectedExceptionType_Data => new()
    {
        {
            () => ResolverBuilder<TestResources>.ValueOf<ResourceManager>(InvalidResourceManagerName),
            typeof(InvalidResourceResolutionException<TestResources, ResourceManager>)
        }
    };
}