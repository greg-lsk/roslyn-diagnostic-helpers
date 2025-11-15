using RoslynHelpers._Internals.ResourceResolving;


namespace RoslynHelpers.LocalizableResource;

public readonly struct AnalyzerMessageFormat : IResource
{
    public readonly string GetFrom<TResources>() where TResources : class
        => DiagnosticDescriptorResourceResolver<TResources>.ForMessageFormat();
}