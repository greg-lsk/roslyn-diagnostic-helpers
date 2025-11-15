using Microsoft.CodeAnalysis;
using RoslynHelpers.Tests.ResourceResolving.TestData;
using RoslynHelpers.Tests.LocalizableResource.TestData;


namespace RoslynHelpers.Tests.LocalizableResource;

public class LocalizableStringCreationTests
{
    public static TheoryData<LocalizableString, string> FromHelperAndNameofSourceMemberNoFormatCollection
        => ResourceResolvingTestData.FromHelperAndNameofSourceMemberNoFormatData;

    public static TheoryData<LocalizableString, string> FromHelperAndNameofSourceMemberFormatCollection
        => ResourceResolvingTestData.FromHelperAndNameofSourceMemberFormatData;


    [Theory]
    [MemberData(nameof(FromHelperAndNameofSourceMemberNoFormatCollection))]
    internal void YieldsSameResultAs_LocalizableResourceStringCtor_NoFormat(LocalizableString fromHelper, string nameofSourceMember)
    {
        var withNoFormatFromCtor = new LocalizableResourceString
        (
            nameofSourceMember,
            TestResources.ResourceManager,
            typeof(TestResources)
        );

        Assert.True(fromHelper.Equals(withNoFormatFromCtor));
    }

    [Theory]
    [MemberData(nameof(FromHelperAndNameofSourceMemberFormatCollection))]
    internal void YieldsSameResultAs_LocalizableResourceStringCtor_Format(LocalizableString fromHelper, string nameofSourceMember)
    {
        var withFormatFromCtor = new LocalizableResourceString
        (
            nameofSourceMember,
            TestResources.ResourceManager,
            typeof(TestResources),
            ResourceResolvingTestData.DummyFormat
        );

        Assert.True(fromHelper.Equals(withFormatFromCtor));
    }
}