using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;


namespace RoslynHelpers.Exceptions;

public sealed class InvalidResourceResolutionException<TResourceSource>(string resource, params BindingFlags[] bindingFlags) 
    : Exception 
    where TResourceSource : class
{
    public string Resource { get; } = resource;
    public IEnumerable<BindingFlags> BindingFlags { get; } = bindingFlags;

    public override string Message => $"" +
        $"{typeof(TResourceSource)} " +
        $"does not contain a {String.Join(", ", BindingFlags.Select(bf => bf.ToString()))} property " +
        $"named {Resource}";
}