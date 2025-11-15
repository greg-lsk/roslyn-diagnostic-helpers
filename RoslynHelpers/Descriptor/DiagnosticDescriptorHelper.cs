using Microsoft.CodeAnalysis;


namespace RoslynHelpers.Descriptor;

public static class DiagnosticDescriptorHelper
{ 
    public static DiagnosticDescriptor Create<TDescriptor>() where TDescriptor : struct, IDiagnosticDescriptor
    {
        return new TDescriptor().Create();
    }

    public static DiagnosticDescriptor CreateLocalizable<TDescriptor>() where TDescriptor : struct, ILocalizableDiagnosticDescriptor
    {
        return new TDescriptor().Create();
    }
}