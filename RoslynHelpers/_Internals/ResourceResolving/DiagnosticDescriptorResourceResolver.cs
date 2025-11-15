using System.Resources;


namespace RoslynHelpers._Internals.ResourceResolving;

internal static class DiagnosticDescriptorResourceResolver<TResourceSource> where TResourceSource : class
{
    internal readonly static Resolver<TResourceSource, string> ForTitle 
        = ResolverBuilder<TResourceSource>.NameOf<string>(ResourceIdentifiers.AnalyzerTitle);
    
    internal readonly static Resolver<TResourceSource, string> ForDescription 
        = ResolverBuilder<TResourceSource>.NameOf<string>(ResourceIdentifiers.AnalyzerDescription);
    
    internal readonly static Resolver<TResourceSource, string> ForMessageFormat 
        = ResolverBuilder<TResourceSource>.NameOf<string>(ResourceIdentifiers.AnalyzerMessageFormat);

    internal readonly static Resolver<TResourceSource, ResourceManager> ForResourceManager 
        = ResolverBuilder<TResourceSource>.ValueOf<ResourceManager>(ResourceIdentifiers.AnalyzerResourceManager);
}