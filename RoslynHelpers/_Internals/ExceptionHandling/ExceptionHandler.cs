using System.Reflection;
using RoslynHelpers.Exceptions;


namespace RoslynHelpers._Internals.ExceptionHandling;

internal static class ExceptionHandler
{
    internal static InvalidResourceResolutionException<TResourceSource> ForInvalidResourceResolution<TResourceSource>(
        string resource,
        params BindingFlags[] bindingFlags
    ) where TResourceSource : class => new(resource, bindingFlags);
}