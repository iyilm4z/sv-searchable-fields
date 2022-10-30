using SimonsVoss.SearchableFields.Web.Core;

namespace SimonsVoss.SearchableFields.Web.Models.Extensions;

public static class GroupModelExtensions
{
    public const int NameSearchingWeight = 9;
    public const int NameTransitiveSearchingWeight = 8;
    public const int DescriptionSearchingWeight = 5;
    public const int DescriptionTransitiveSearchingWeight = 0;

    public static int Calculate(this GroupModel groupModel, string textToSearch, bool isTransitive = false)
    {
        var totalSearchingWeight = PropertySearchingWeightHelper.GetPropertySearchingWeight(textToSearch,
            groupModel.Name, !isTransitive ? NameSearchingWeight : NameTransitiveSearchingWeight);
        totalSearchingWeight += PropertySearchingWeightHelper.GetPropertySearchingWeight(textToSearch,
            groupModel.Description, !isTransitive ? DescriptionSearchingWeight : DescriptionTransitiveSearchingWeight);

        return totalSearchingWeight;
    }
}