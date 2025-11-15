using System;
using System.Reflection;
using RoslynHelpers.Exceptions;


namespace RoslynHelpers._Internals.ExceptionHandling;

internal static class ExceptionHandler
{
    internal static InvalidResourceResolutionException<TResourceSource, TResource> ForInvalidResourceResolution<TResourceSource, TResource>(
        string resource,
        params BindingFlags[] bindingFlags
    ) where TResourceSource : class => new(resource, bindingFlags);
}