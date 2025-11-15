using System.Reflection;
using System.Linq.Expressions;
using RoslynHelpers._Internals.ExceptionHandling;


namespace RoslynHelpers._Internals.ResourceResolving;

internal static class ResolverBuilder<TResourceSource> where TResourceSource : class
{
    internal static Resolver<TResourceSource, TResource> ValueOf<TResource>(string resourceName)
    {
        var propertyInfo = TryGetProperty<TResource>(resourceName);

        var propertyAccess = Expression.MakeMemberAccess(null, propertyInfo);

        var lambda = Expression.Lambda<Resolver<TResourceSource, TResource>>(propertyAccess);
        return lambda.Compile();
    }

    internal static Resolver<TResourceSource, string> NameOf<TResource>(string resourceName)
    {
        var propertyInfo = TryGetProperty<TResource>(resourceName);

        var propertyName = Expression.Constant(propertyInfo.Name);

        var lambda = Expression.Lambda<Resolver<TResourceSource, string>>(propertyName);
        return lambda.Compile();
    }


    private static PropertyInfo TryGetProperty<T>(string propertyName)
    {
        return typeof(TResourceSource).GetProperty(propertyName, BindingFlags.Static | BindingFlags.NonPublic) 
        ?? throw ExceptionHandler.ForInvalidResourceResolution<TResourceSource, T>
        (
            propertyName,
            BindingFlags.Static,
            BindingFlags.NonPublic
        ); 
    }
}