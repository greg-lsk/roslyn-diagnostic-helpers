using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;


namespace RoslynHelpers.TypeResolution.Exceptions;

public sealed class UnableToResolveException<TResourceSource, TResource> : Exception
{
    public string TargetName { get; }
    public IEnumerable<BindingFlags> BindingFlags { get; }

    public override string Message => CreateMessage(TargetName, BindingFlags);


    public UnableToResolveException(string targetNesource, params BindingFlags[] bindingFlags)
    {
        TargetName = targetNesource;
        BindingFlags = bindingFlags;
    }

    public UnableToResolveException(string targetName, Exception inner, params BindingFlags[] bindingFlags)
        :base (CreateMessage(targetName, bindingFlags), inner)
    {
        TargetName = targetName;
        BindingFlags = bindingFlags;
    }


    private static string CreateMessage(string targetName, IEnumerable<BindingFlags>flags) =>
    $"\n" +
    $"reason:: {Reason()}\n" +
    $"target:: {JoinFlags(flags)} {ShortenTypeOf<TResource>()} {targetName}\n" +
    $"source:: {ShortenTypeOf<TResourceSource>()}\n" +
    $"\n" +
    $"target-verbose:: {typeof(TResource)}" +
    $"source-verbose:: {typeof(TResourceSource)}\n";


    private static string Reason() => "Couldn't resolve";
    private static string ShortenTypeOf<T>() => typeof(T).FullName.Split('.').LastOrDefault();
    private static string JoinFlags(IEnumerable<BindingFlags> flags) => string.Join(", ", flags.Select(f => f.ToString()));
}