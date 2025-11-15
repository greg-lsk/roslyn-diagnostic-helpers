namespace RoslynHelpers._Internals.ResourceResolving;

internal static class AnalyzerDescriptionResolver<TResource> where TResource : class
{
    internal static readonly Resolver<TResource> Get = ResolverBuilder.Build<TResource>(ResourceIdentifiers.AnalyzerDescription);
}