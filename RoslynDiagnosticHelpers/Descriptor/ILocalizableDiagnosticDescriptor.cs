using Microsoft.CodeAnalysis;


namespace RoslynDiagnosticHelpers.Descriptor;

public interface ILocalizableDiagnosticDescriptor
{
    public DiagnosticDescriptor Create();
}