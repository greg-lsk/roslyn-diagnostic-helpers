using System.Resources;
using Microsoft.CodeAnalysis;
using RoslynHelpers.LocalizableResource;
using RoslynHelpers._Internals.ResourceResolving;
using RoslynHelpers.Tests.LocalizableResource.TestData;


namespace RoslynHelpers.Tests.ResourceResolving.TestData;

internal static class ResourceResolvingTestData
{
    internal static TheoryData<(Delegate BuilderResult, Type ExpectedResolverType)> BuilderReturnsExpectedResolver_Data => 
    [
        (
            BuilderResult:        ResolverBuilder<TestResources>.ValueOf<string>(ResourceIdentifiers.AnalyzerTitle),
            ExpectedResolverType: typeof(Resolver<TestResources, string>) 
        ),
        (
            BuilderResult:        ResolverBuilder<TestResources>.ValueOf<string>(ResourceIdentifiers.AnalyzerDescription),
            ExpectedResolverType: typeof(Resolver<TestResources, string>)
        ),
        (
            BuilderResult:        ResolverBuilder<TestResources>.ValueOf<string>(ResourceIdentifiers.AnalyzerMessageFormat),
            ExpectedResolverType: typeof(Resolver<TestResources, string>)
        ),
        (
            BuilderResult:        ResolverBuilder<TestResources>.ValueOf<ResourceManager>(ResourceIdentifiers.AnalyzerResourceManager),
            ExpectedResolverType: typeof(Resolver<TestResources, ResourceManager>)
        )
    ];

    internal static TheoryData<IResource, string> IResourceToSourceResourceMember_ValidMap => new()
    {
        {new AnalyzerTitle(), nameof(TestResources.AnalyzerTitle)},
        {new AnalyzerDescription(), nameof(TestResources.AnalyzerDescription)},
        {new AnalyzerMessageFormat(),nameof(TestResources.AnalyzerMessageFormat)}
    };

    internal static TheoryData<LocalizableString, string> FromHelper_NameofSourceMember_NoFormat_Data => new()
    {
        {
            LocalizableStringHelper.From<TestResources, AnalyzerTitle>(),
            nameof(TestResources.AnalyzerTitle)
        },
        {
            LocalizableStringHelper.From<TestResources, AnalyzerDescription>(),
            nameof(TestResources.AnalyzerDescription)
        },
        {
            LocalizableStringHelper.From<TestResources, AnalyzerMessageFormat>(),
            nameof(TestResources.AnalyzerMessageFormat)
        }
    };

    internal static string[] DummyFormat => ["asdasda", "vvvv"];
    internal static TheoryData<LocalizableString, string> FromHelper_NameofSourceMember_Format_Data => new()
    {
        {
            LocalizableStringHelper.From<TestResources, AnalyzerTitle>(DummyFormat),
            nameof(TestResources.AnalyzerTitle)
        },
        {
            LocalizableStringHelper.From<TestResources, AnalyzerDescription>(DummyFormat),
            nameof(TestResources.AnalyzerDescription)
        },
        {
            LocalizableStringHelper.From<TestResources, AnalyzerMessageFormat>(DummyFormat),
            nameof(TestResources.AnalyzerMessageFormat)
        }
    };
}