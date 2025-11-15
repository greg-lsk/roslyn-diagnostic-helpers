using RoslynHelpers.Tests.ResourceResolving.TestData;


namespace RoslynHelpers.Tests.ResourceResolving;

public class ResolverBuilderTest
{
    public static TheoryData<(Delegate, Type)> ReturnsExpectedResolver 
        => ResourceResolvingTestData.BuilderReturnsExpectedResolver_Data;

    public static TheoryData<Action, Type> InvalidResolverBuilderInvocation_ExpectedExceptionType => 
        ResourceResolvingExceptionsTestData.InvalidResolverBuilderInvocation_ExpectedExceptionType_Data;

    [Theory]
    [MemberData(nameof(ReturnsExpectedResolver))]
    internal void CreatesExpected_ResolverDelegate((Delegate BuilderResult, Type ExpectedType) theoryData)
    {
        Assert.NotNull(theoryData.BuilderResult);
        Assert.Equal(theoryData.BuilderResult.GetType(), theoryData.ExpectedType);
    }

    [Theory]
    [MemberData(nameof(InvalidResolverBuilderInvocation_ExpectedExceptionType))]
    internal void Throws_WhenProvidedName_DoesNotMeatExpectedReflectionCriteria(Action invalidInvocation, Type expectedExceptionType)
    {
        var caught = Record.Exception(invalidInvocation);

        Assert.Equal(caught.GetType(), expectedExceptionType);
    }
}