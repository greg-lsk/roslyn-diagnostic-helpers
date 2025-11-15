namespace RoslynHelpers.LocalizableResource;

public interface IResource
{
    public string GetFrom<TResources>() where TResources : class;
}