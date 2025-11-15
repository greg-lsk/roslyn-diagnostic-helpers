using Microsoft.CodeAnalysis;


namespace RoslynHelpers.Descriptor;

public interface IDiagnosticDescriptor
{
    public DiagnosticDescriptor Create();
}