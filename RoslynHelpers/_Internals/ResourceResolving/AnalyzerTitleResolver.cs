namespace RoslynHelpers._Internals.ResourceResolving;

internal static class AnalyzerTitleResolver<TResource> where TResource : class
{
    internal static readonly Resolver<TResource> Get = ResolverBuilder.Build<TResource>(ResourceIdentifiers.AnalyzerTitle);
}