using System.Resources;
using System.Reflection;
using System.Linq.Expressions;
using RoslynHelpers._Internals.ExceptionHandling;


namespace RoslynHelpers._Internals.ResourceResolving;

internal delegate ResourceManager ResourceManagerResolver<TResource>() where TResource : class;

internal static class AnalyzerResourceManagerResolver<TResource> where TResource : class
{
    internal readonly static ResourceManagerResolver<TResource> Get = BuildResolver(); 

    private static ResourceManagerResolver<TResource> BuildResolver()
    {
        var resourceType = typeof(TResource);

        var propertyInfo = resourceType.GetProperty(ResourceIdentifiers.AnalyzerResourceManager, BindingFlags.Static | BindingFlags.NonPublic)
            ?? throw ExceptionHandler.ForInvalidResourceResolution<TResource>
            (
                ResourceIdentifiers.AnalyzerResourceManager, 
                BindingFlags.Static, 
                BindingFlags.NonPublic
            );

        var propertyAccess = Expression.Property(null, propertyInfo);
        return Expression.Lambda<ResourceManagerResolver<TResource>>(propertyAccess).Compile();
    }
}