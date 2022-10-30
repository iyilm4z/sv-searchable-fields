using SimonsVoss.SearchableFields.Web.Core;

namespace SimonsVoss.SearchableFields.Web.Models;

public class GroupModel : SearchableModel<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }

    public override string ModelType => "Group";
}