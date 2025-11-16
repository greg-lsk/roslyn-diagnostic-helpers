using System.Resources;
using RoslynHelpers.Tests._Common;
using RoslynHelpers.Descriptor.ResourceResolution;
using RoslynHelpers.TypeResolution;


namespace RoslynHelpers.Tests.ResourceResolving.TestData;

internal static class ResourceResolvingTestData
{
    internal static TheoryData<(Delegate BuilderResult, Type ExpectedResolverType)> BuilderReturnsExpectedResolver_Data => 
    [
        (
            BuilderResult:        ResolverBuilder<StubResources>.ValueOf<string>(ResourceIdentifiers.AnalyzerTitle),
            ExpectedResolverType: typeof(Resolver<StubResources, string>) 
        ),
        (
            BuilderResult:        ResolverBuilder<StubResources>.ValueOf<string>(ResourceIdentifiers.AnalyzerDescription),
            ExpectedResolverType: typeof(Resolver<StubResources, string>)
        ),
        (
            BuilderResult:        ResolverBuilder<StubResources>.ValueOf<string>(ResourceIdentifiers.AnalyzerMessageFormat),
            ExpectedResolverType: typeof(Resolver<StubResources, string>)
        ),
        (
            BuilderResult:        ResolverBuilder<StubResources>.ValueOf<ResourceManager>(ResourceIdentifiers.AnalyzerResourceManager),
            ExpectedResolverType: typeof(Resolver<StubResources, ResourceManager>)
        )
    ];
}