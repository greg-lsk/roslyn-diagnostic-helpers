using System.Resources;
using RoslynHelpers.Tests._Common;
using RoslynHelpers.Tests.ResourceResolving.TestData;
using RoslynHelpers.TypeResolution;
using RoslynHelpers.TypeResolution.Exceptions;


namespace RoslynHelpers.Tests.ResourceResolving;

public class ResolverBuilderTest
{
    public static TheoryData<(Delegate, Type)> ReturnsExpectedResolver 
        => ResourceResolvingTestData.BuilderReturnsExpectedResolver_Data;


    [Theory]
    [MemberData(nameof(ReturnsExpectedResolver))]
    internal void CreatesExpected_ResolverDelegate((Delegate BuilderResult, Type ExpectedType) theoryData)
    {
        Assert.NotNull(theoryData.BuilderResult);
        Assert.Equal(theoryData.BuilderResult.GetType(), theoryData.ExpectedType);
    }

    [Fact]
    internal void Throws_WhenProvidedName_DoesNotMeatExpectedReflectionCriteria()
    {
        var invalidResourceMemberName = "ResourceManagggger";

        Assert.Throws<UnableToResolveException<StubResources, ResourceManager>>
        (
            () => ResolverBuilder<StubResources>.ValueOf<ResourceManager>(invalidResourceMemberName)
        );
    }
}