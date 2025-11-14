using System.Resources;
using Microsoft.CodeAnalysis;


namespace RoslynHelpers.LocalizableResource;

public static class LocalizableStringHelper
{
    public static LocalizableString From<TResource>(string resourceName, ResourceManager resourceManager)
    {
        return new LocalizableResourceString(resourceName, resourceManager, typeof(TResource));
    }

    public static LocalizableString From<TResource>(string resourceName, ResourceManager resourceManager, params string[] formatArguments)
    {
        return new LocalizableResourceString(resourceName, resourceManager, typeof(TResource), formatArguments);
    }
}