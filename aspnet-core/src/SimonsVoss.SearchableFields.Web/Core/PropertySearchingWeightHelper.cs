namespace SimonsVoss.SearchableFields.Web.Core;

public class PropertySearchingWeightHelper
{
    public const int FullMatchMultiplier = 10;

    public static int GetPropertySearchingWeight(string textToSearch, string propertyValue,
        int propertySearchingWeight)
    {
        if (string.IsNullOrEmpty(textToSearch) || string.IsNullOrEmpty(propertyValue))
        {
            return 0;
        }

        if (propertyValue.Equals(textToSearch, StringComparison.OrdinalIgnoreCase))
        {
            return propertySearchingWeight * FullMatchMultiplier;
        }

        if (propertyValue.Contains(textToSearch, StringComparison.OrdinalIgnoreCase))
        {
            return propertySearchingWeight;
        }

        return 0;
    }
}