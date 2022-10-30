using SimonsVoss.SearchableFields.Web.Core;

namespace SimonsVoss.SearchableFields.Web.Models.Extensions;

public static class LockModelExtensions
{
    public const int TypeSearchingWeight = 3;
    public const int NameSearchingWeight = 10;
    public const int SerialNumberSearchingWeight = 8;
    public const int FloorSearchingWeight = 6;
    public const int RoomNumberSearchingWeight = 6;
    public const int DescriptionSearchingWeight = 6;

    public static int Calculate(this LockModel lockModel, string textToSearch)
    {
        var totalSearchingWeight = PropertySearchingWeightHelper.GetPropertySearchingWeight(textToSearch,
            lockModel.Type, TypeSearchingWeight);
        totalSearchingWeight += PropertySearchingWeightHelper.GetPropertySearchingWeight(textToSearch,
            lockModel.Name, NameSearchingWeight);
        totalSearchingWeight += PropertySearchingWeightHelper.GetPropertySearchingWeight(textToSearch,
            lockModel.SerialNumber, SerialNumberSearchingWeight);
        totalSearchingWeight += PropertySearchingWeightHelper.GetPropertySearchingWeight(textToSearch,
            lockModel.Floor, FloorSearchingWeight);
        totalSearchingWeight += PropertySearchingWeightHelper.GetPropertySearchingWeight(textToSearch,
            lockModel.RoomNumber, RoomNumberSearchingWeight);
        totalSearchingWeight += PropertySearchingWeightHelper.GetPropertySearchingWeight(textToSearch,
            lockModel.Description, DescriptionSearchingWeight);

        return totalSearchingWeight;
    }
}