using RoslynHelpers._Internals.ResourceResolving;


namespace RoslynHelpers.Tests.ResourceResolving.TestData;

internal static class ResourceResolvingExceptionsTestData
{
    internal static string NonExistantResource => "AnalyzerLogger";
    internal static class NonExistantResourceResolver<TResource> where TResource : class
    {
        internal readonly static Resolver<TResource> Get = ResolverBuilder.Build<TResource>(NonExistantResource);
    }
}