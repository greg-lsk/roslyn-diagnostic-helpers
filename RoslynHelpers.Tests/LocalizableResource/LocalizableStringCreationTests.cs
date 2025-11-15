using Microsoft.CodeAnalysis;
using RoslynHelpers.Tests.ResourceResolving.TestData;
using RoslynHelpers.Tests.LocalizableResource.TestData;


namespace RoslynHelpers.Tests.LocalizableResource;

public class LocalizableStringCreationTests
{
    public static TheoryData<LocalizableString, string> FromHelper_NameofSourceMember_NoFormat
        => ResourceResolvingTestData.FromHelper_NameofSourceMember_NoFormat_Data;

    public static TheoryData<LocalizableString, string> FromHelper_NameofSourceMember_Format
        => ResourceResolvingTestData.FromHelper_NameofSourceMember_Format_Data;


    [Theory]
    [MemberData(nameof(FromHelper_NameofSourceMember_NoFormat))]
    internal void YieldsSameResultAs_LocalizableResourceStringCtor_NoFormat(LocalizableString fromHelper, string nameofSourceMember)
    {
        var fromCtor = new LocalizableResourceString
        (
            nameofSourceMember,
            TestResources.ResourceManager,
            typeof(TestResources)
        );

        Assert.True(fromHelper.Equals(fromCtor));
    }

    [Theory]
    [MemberData(nameof(FromHelper_NameofSourceMember_Format))]
    internal void YieldsSameResultAs_LocalizableResourceStringCtor_Format(LocalizableString fromHelper, string nameofSourceMember)
    {
        var fromCtor = new LocalizableResourceString
        (
            nameofSourceMember,
            TestResources.ResourceManager,
            typeof(TestResources),
            ResourceResolvingTestData.DummyFormat
        );

        Assert.True(fromHelper.Equals(fromCtor));
    }
}