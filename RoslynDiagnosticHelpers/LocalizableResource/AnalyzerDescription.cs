using RoslynHelpers._Internals.ResourceResolving;


namespace RoslynHelpers.LocalizableResource;

public readonly struct AnalyzerDescription : IResource
{
    public string GetFrom<TResources>() where TResources : class => AnalyzerDescriptionResolver<TResources>.Get();
}