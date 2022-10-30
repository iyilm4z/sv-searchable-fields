using System.Text.Json;

namespace SimonsVoss.SearchableFields.Web.Data;

public class JsonDataImporter : IJsonDataImporter
{
    public const string JsonDataFileName = "data.json";
    
    private JsonData? _jsonDataCache;

    private readonly IWebHostEnvironment _environment;

    public JsonDataImporter(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public JsonData GetJsonData()
    {
        if (_jsonDataCache != null)
        {
            return _jsonDataCache;
        }

        var jsonDataPath = Path.Combine(_environment.WebRootPath, "data.json");

        var jsonDataContent = File.ReadAllText(jsonDataPath);

        var jsonData = JsonSerializer.Deserialize<JsonData>(jsonDataContent);

        if (jsonData == null)
        {
            return JsonData.Empty;
        }

        MapGroupsToMedias(jsonData);

        MapBuildingsToLocks(jsonData);

        return _jsonDataCache = jsonData;
    }

    protected virtual void MapGroupsToMedias(JsonData jsonData)
    {
        var mediasWithGroups = jsonData.Medias
            .Where(x => x.GroupId.HasValue)
            .ToList();

        foreach (var media in mediasWithGroups)
        {
            var group = jsonData.Groups.FirstOrDefault(x => x.Id == media.GroupId);
            if (group == null)
            {
                throw new ApplicationException($"Media has non-existing Group. Related GroupId={media.GroupId}");
            }

            media.Group = group;
        }
    }

    protected virtual void MapBuildingsToLocks(JsonData jsonData)
    {
        var locksWithBuildings = jsonData.Locks
            .Where(x => x.BuildingId.HasValue)
            .ToList();

        foreach (var @lock in locksWithBuildings)
        {
            var building = jsonData.Buildings.FirstOrDefault(x => x.Id == @lock.BuildingId);
            if (building == null)
            {
                throw new ApplicationException(
                    $"Lock has non-existing Building. Related BuildingId={@lock.BuildingId}");
            }

            @lock.Building = building;
        }
    }
}