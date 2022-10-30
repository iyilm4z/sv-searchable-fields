using SimonsVoss.SearchableFields.Web.Core;

namespace SimonsVoss.SearchableFields.Web.Models.Extensions;

public static class MediaModelExtensions
{
    public const int TypeSearchingWeight = 3;
    public const int OwnerSearchingWeight = 10;
    public const int SerialNumberSearchingWeight = 8;
    public const int DescriptionSearchingWeight = 6;

    public static int Calculate(this MediaModel mediaModel, string textToSearch)
    {
        var totalSearchingWeight = PropertySearchingWeightHelper.GetPropertySearchingWeight(textToSearch,
            mediaModel.Type, TypeSearchingWeight);
        totalSearchingWeight += PropertySearchingWeightHelper.GetPropertySearchingWeight(textToSearch,
            mediaModel.Owner, OwnerSearchingWeight);
        totalSearchingWeight += PropertySearchingWeightHelper.GetPropertySearchingWeight(textToSearch,
            mediaModel.SerialNumber, SerialNumberSearchingWeight);
        totalSearchingWeight += PropertySearchingWeightHelper.GetPropertySearchingWeight(textToSearch,
            mediaModel.Description, DescriptionSearchingWeight);

        return totalSearchingWeight;
    }
}