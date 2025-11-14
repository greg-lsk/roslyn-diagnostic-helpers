using Microsoft.CodeAnalysis;
using RoslynHelpers.LocalizableResource;
using RoslynHelpers.Tests.LocalizableResource.TestData;


namespace RoslynHelpers.Tests.LocalizableResource;

public class LocalizableStringCreationTests
{
    [Fact]
    public void CreatesLocalizableResourceString()
    {
        var withNoFormat = LocalizableStringHelper.From<TestResources>
        (
            TestResources.TestLocalizableResource,
            TestResources.ResourceManager
        );

        var withFormat = LocalizableStringHelper.From<TestResources>
        (
            TestResources.TestLocalizableResource,
            TestResources.ResourceManager,
            ["a", "ddd"]
        );

        Assert.IsType<LocalizableResourceString>(withNoFormat);
        Assert.IsType<LocalizableResourceString>(withFormat);
    }

    [Fact]
    public void YieldsSameResultAs_LocalizableResourceStringCtor()
    {
        var withNoFormatFromHelper = LocalizableStringHelper.From<TestResources>
        (
            TestResources.TestLocalizableResource,
            TestResources.ResourceManager
        );
        var withNoFormatFromCtor = new LocalizableResourceString
        (
            TestResources.TestLocalizableResource,
            TestResources.ResourceManager,
            typeof(TestResources)
        );


        var withFormatFromHelper = LocalizableStringHelper.From<TestResources>
        (
            TestResources.TestLocalizableResource,
            TestResources.ResourceManager,
            ["a", "ddd"]
        );
        var withFormatFromCtor = new LocalizableResourceString
        (
            TestResources.TestLocalizableResource,
            TestResources.ResourceManager,
            typeof(TestResources),
            ["a", "ddd"]
        );


        Assert.True(withNoFormatFromHelper.Equals(withNoFormatFromCtor));
        Assert.True(withFormatFromHelper.Equals(withFormatFromCtor));
    }
}
