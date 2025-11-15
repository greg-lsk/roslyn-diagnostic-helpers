using RoslynHelpers._Internals.ResourceResolving;


namespace RoslynHelpers.LocalizableResource;

public readonly struct AnalyzerTitle : IResource
{
    public readonly string GetFrom<TResource>() where TResource : class
        => DiagnosticDescriptorResourceResolver<TResource>.ForTitle();
}