using Moq;
using RoslynHelpers.LocalizableResource;
using RoslynHelpers.Tests.LocalizableResource.TestData;
using static RoslynHelpers.Tests.ResourceResolving.TestData.ResourceResolvingExceptionsTestData;


namespace RoslynHelpers.Tests.ResourceResolving.TestData;

internal static class ResourceResolvingExceptionsMocks
{
    internal static void InvalidMemberOfExistantResourceMock(out Mock<IResource> mock)
    {
        mock = new();
        mock.Setup(m => m.GetFrom<TestResources>())
            .Callback(() => NonExistantResourceResolver<TestResources>.Get());
    }
}