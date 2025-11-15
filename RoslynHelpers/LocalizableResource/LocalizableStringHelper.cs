using Microsoft.CodeAnalysis;
using RoslynHelpers._Internals.ResourceResolving;


namespace RoslynHelpers.LocalizableResource;

public static class LocalizableStringHelper
{
    public static LocalizableString From<TResource, TResourceId>()
        where TResource : class
        where TResourceId : struct, IResource
    {
        return new LocalizableResourceString
        (
            nameOfLocalizableResource: new TResourceId().GetFrom<TResource>(), 
            resourceManager:           AnalyzerResourceManagerResolver<TResource>.Get(),
            resourceSource:            typeof(TResource)
        );
    }

    public static LocalizableString From<TResource, TResourceId>(params string[] formatArguments)
        where TResource : class
        where TResourceId : struct, IResource
    {
        return new LocalizableResourceString
        (
            nameOfLocalizableResource: new TResourceId().GetFrom<TResource>(),
            resourceManager:           AnalyzerResourceManagerResolver<TResource>.Get(),
            resourceSource:            typeof(TResource),
            formatArguments:           formatArguments
        );
    }
}