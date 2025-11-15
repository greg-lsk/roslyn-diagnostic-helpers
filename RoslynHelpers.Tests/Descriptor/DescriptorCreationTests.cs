using Microsoft.CodeAnalysis;
using RoslynHelpers.Descriptor;
using static RoslynHelpers.Tests.Descriptor.TestData.DescriptorTestData;


namespace RoslynHelpers.Tests.Descriptor;

public class DescriptorCreationTests
{
    [Fact]
    internal void TypeCreatedIsDiagnosticDescriptor()
    {
        var created = DiagnosticDescriptorHelper.Create<UnlocalizableDescriptor>();
        Assert.IsType<DiagnosticDescriptor>(created);
    }
}