using System.Reflection;
using System.Linq.Expressions;
using RoslynHelpers._Internals.ExceptionHandling;


namespace RoslynHelpers._Internals.ResourceResolving;

internal delegate string Resolver<TResource>() where TResource : class;

internal static class ResolverBuilder
{
    internal static Resolver<TResource> Build<TResource>(string resource) where TResource : class
    {
        var resourceType = typeof(TResource);

        var propertyInfo = resourceType.GetProperty(resource, BindingFlags.Static | BindingFlags.NonPublic)
            ?? throw ExceptionHandler.ForInvalidResourceResolution<TResource>
            (
                resource,
                BindingFlags.Static,
                BindingFlags.NonPublic
            );

        var nameOfProperty = Expression.Constant(propertyInfo.Name);

        var lambda = Expression.Lambda<Resolver<TResource>>(nameOfProperty);
        return lambda.Compile();
    }
}