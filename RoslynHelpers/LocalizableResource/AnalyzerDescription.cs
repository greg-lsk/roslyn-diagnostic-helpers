using RoslynHelpers._Internals.ResourceResolving;


namespace RoslynHelpers.LocalizableResource;

public readonly struct AnalyzerDescription : IResource
{
    public string GetFrom<TResourceSource>() where TResourceSource : class
        => DiagnosticDescriptorResourceResolver<TResourceSource>.ForDescription();
}