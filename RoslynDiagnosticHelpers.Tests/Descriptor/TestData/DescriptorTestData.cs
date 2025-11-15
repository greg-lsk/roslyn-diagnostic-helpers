using Microsoft.CodeAnalysis;
using RoslynHelpers.Descriptor;


namespace RoslynHelpers.Tests.Descriptor.TestData;

internal class DescriptorTestData
{
    internal readonly struct UnlocalizableDescriptor : IDiagnosticDescriptor
    {
        public readonly DiagnosticDescriptor Create() => new
        (
            id: "Id", 
            title: "Title", 
            messageFormat: "Message", 
            category: "Category", 
            defaultSeverity: DiagnosticSeverity.Warning, 
            isEnabledByDefault: true
        );
    }
}