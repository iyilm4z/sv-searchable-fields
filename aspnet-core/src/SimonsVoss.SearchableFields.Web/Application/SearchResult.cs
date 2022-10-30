using SimonsVoss.SearchableFields.Web.Models;

namespace SimonsVoss.SearchableFields.Web.Application;

public class SearchResult
{
    public List<GroupModel> Groups { get; set; }

    public List<MediaModel> Medias { get; set; }

    public List<BuildingModel> Buildings { get; set; }

    public List<LockModel> Locks { get; set; }

    public List<Guid> OrderedModelIds { get; set; }
}