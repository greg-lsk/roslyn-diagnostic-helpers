using System;
using System.Reflection;
using System.Collections.Generic;


namespace RoslynHelpers.Exceptions;

public sealed class InvalidResourceResolutionException<TResourceSource, TResource>
    : Exception
    where TResourceSource : class
{
    public string ResourceName { get; }
    public IEnumerable<BindingFlags> BindingFlags { get; }

    public override string Message => CreateMessage(ResourceName, BindingFlags);


    public InvalidResourceResolutionException(string resource, params BindingFlags[] bindingFlags)
    {
        ResourceName = resource;
        BindingFlags = bindingFlags;
    }

    public InvalidResourceResolutionException(string resource, Exception inner, params BindingFlags[] bindingFlags)
        :base (CreateMessage(resource, bindingFlags), inner)
    {
        ResourceName = resource;
        BindingFlags = bindingFlags;
    }


    private static string CreateMessage(string resource, IEnumerable<BindingFlags>flags)
    {
        return ExceptionMessages.ForInvalidResourceResolution<TResourceSource, TResource>(resource, flags);
    }
}