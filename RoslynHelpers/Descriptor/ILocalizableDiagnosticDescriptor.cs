using Microsoft.CodeAnalysis;


namespace RoslynHelpers.Descriptor;

public interface ILocalizableDiagnosticDescriptor
{
    public DiagnosticDescriptor Create();
}