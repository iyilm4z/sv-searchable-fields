using SimonsVoss.SearchableFields.Web.Core;

namespace SimonsVoss.SearchableFields.Web.Models.Extensions;

public static class BuildingModelExtensions
{
    public const int ShortCutSearchingWeight = 7;
    public const int ShortCutTransitiveSearchingWeight = 5;
    public const int NameSearchingWeight = 9;
    public const int NameTransitiveSearchingWeight = 8;
    public const int DescriptionSearchingWeight = 5;
    public const int DescriptionTransitiveSearchingWeight = 0;

    public static int Calculate(this BuildingModel buildingModel, string textToSearch, bool isTransitive = false)
    {
        var totalSearchingWeight = PropertySearchingWeightHelper.GetPropertySearchingWeight(textToSearch,
            buildingModel.ShortCut, !isTransitive ? ShortCutSearchingWeight : ShortCutTransitiveSearchingWeight);
        totalSearchingWeight += PropertySearchingWeightHelper.GetPropertySearchingWeight(textToSearch,
            buildingModel.Name, !isTransitive ? NameSearchingWeight : NameTransitiveSearchingWeight);
        totalSearchingWeight += PropertySearchingWeightHelper.GetPropertySearchingWeight(textToSearch,
            buildingModel.Description, !isTransitive ? DescriptionSearchingWeight : DescriptionTransitiveSearchingWeight);

        return totalSearchingWeight;
    }
}