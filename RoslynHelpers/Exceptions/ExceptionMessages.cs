using System.Linq;
using System.Reflection;
using System.Collections.Generic;


namespace RoslynHelpers.Exceptions;

internal static class ExceptionMessages
{
    internal static string ForInvalidResourceResolution<TResourceSource, TResource>
    (
        string resourceName,
        IEnumerable<BindingFlags> flags
    ) =>
    $"reason::   {Reason()}\n" +
    $"source::   {ShortenTypeOf<TResourceSource>()}\n" +
    $"resource:: {JoinFlags(flags)} {ShortenTypeOf<TResource>()} {resourceName}\n" +
    $"\n" +
    $"source-verbose::  {typeof(TResourceSource)}\n" +
    $"resource-vebose:: {typeof(TResource)}";


    private static string Reason() => "Couldn't find provided resource in source";
    private static string ShortenTypeOf<T>() => typeof(T).FullName.Split('.').LastOrDefault();
    private static string JoinFlags(IEnumerable<BindingFlags> flags) => string.Join(", ", flags.Select(f => f.ToString())); 
}