using Microsoft.CodeAnalysis;


namespace RoslynDiagnosticHelpers.Descriptor;

public interface IDiagnosticDescriptor
{
    public DiagnosticDescriptor Create();
}