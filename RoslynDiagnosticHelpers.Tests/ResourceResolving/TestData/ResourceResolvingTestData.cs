using Microsoft.CodeAnalysis;
using RoslynHelpers.LocalizableResource;
using RoslynHelpers._Internals.ResourceResolving;
using RoslynHelpers.Tests.LocalizableResource.TestData;


namespace RoslynHelpers.Tests.ResourceResolving.TestData;

internal class ResourceResolvingTestData
{
    internal static TheoryData<string> ResourceIdentifierCollectionData =>
    [
        ResourceIdentifiers.AnalyzerTitle,
        ResourceIdentifiers.AnalyzerDescription,
        ResourceIdentifiers.AnalyzerMessageFormat
    ];

    internal static TheoryData<IResource, string> ResourceToClassMemberMappingData => new()
    {
        {new AnalyzerTitle(), nameof(TestResources.AnalyzerTitle)},
        {new AnalyzerDescription(), nameof(TestResources.AnalyzerDescription)},
        {new AnalyzerMessageFormat(),nameof(TestResources.AnalyzerMessageFormat)}
    };

    internal static TheoryData<string, string> ResourceIdentifierToClassMemberMappingData => new()
    {
        {ResourceIdentifiers.AnalyzerTitle, nameof(TestResources.AnalyzerTitle)},
        {ResourceIdentifiers.AnalyzerDescription, nameof(TestResources.AnalyzerDescription)},
        {ResourceIdentifiers.AnalyzerMessageFormat, nameof(TestResources.AnalyzerMessageFormat)}
    };

    internal static TheoryData<LocalizableString, string> FromHelperAndNameofSourceMemberNoFormatData => new()
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
    internal static TheoryData<LocalizableString, string> FromHelperAndNameofSourceMemberFormatData => new()
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