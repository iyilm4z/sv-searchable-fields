using SimonsVoss.SearchableFields.Web.Core;

namespace SimonsVoss.SearchableFields.Web.Models;

public class MediaModel : SearchableModel<Guid>
{
    public string Type { get; set; }
    public string Owner { get; set; }
    public string Description { get; set; }
    public string SerialNumber { get; set; }

    public Guid? GroupId { get; set; }
    public GroupModel Group { get; set; }

    public override string ModelType => "Media";
}