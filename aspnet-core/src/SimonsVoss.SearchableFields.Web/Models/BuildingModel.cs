using SimonsVoss.SearchableFields.Web.Core;

namespace SimonsVoss.SearchableFields.Web.Models;

public class BuildingModel : SearchableModel<Guid>
{
    public string ShortCut { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public override string ModelType => "Building";
}