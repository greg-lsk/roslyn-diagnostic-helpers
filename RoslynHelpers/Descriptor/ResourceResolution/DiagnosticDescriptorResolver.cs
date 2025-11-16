using System.Resources;
using RoslynHelpers.TypeResolution;


namespace RoslynHelpers.Descriptor.ResourceResolution;

internal static class DiagnosticDescriptorResolver<TResourceSource>
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