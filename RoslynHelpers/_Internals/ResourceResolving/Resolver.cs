namespace RoslynHelpers._Internals.ResourceResolving;

internal delegate TResource Resolver<TResourceSource, TResource>() where TResourceSource : class;