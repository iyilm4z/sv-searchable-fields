using SimonsVoss.SearchableFields.Web.Models;

namespace SimonsVoss.SearchableFields.Web.Data;

public class JsonData
{
    public static readonly JsonData Empty = new();

    public List<GroupModel> Groups { get; set; } = new();

    public List<MediaModel> Medias { get; set; } = new();

    public List<BuildingModel> Buildings { get; set; } = new();

    public List<LockModel> Locks { get; set; } = new();
}