using Moq;
using RoslynHelpers.LocalizableResource;
using RoslynHelpers.Tests.LocalizableResource.TestData;
using static RoslynHelpers.Tests.ResourceResolving.TestData.ResourceResolvingExceptionsTestData;


namespace RoslynHelpers.Tests.ResourceResolving.TestData;

public static class ResourceResolvingExceptionsMocks
{
    public static void InvalidMemberOfExistantResourceMock(out Mock<IResource> mock)
    {
        mock = new();
        mock.Setup(m => m.GetFrom<TestResources>())
            .Callback(() => NonExistantResourceResolver<TestResources>.Get());
    }
}