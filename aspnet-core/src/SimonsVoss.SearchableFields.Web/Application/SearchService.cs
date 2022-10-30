using SimonsVoss.SearchableFields.Web.Core;
using SimonsVoss.SearchableFields.Web.Data;
using SimonsVoss.SearchableFields.Web.Models;
using SimonsVoss.SearchableFields.Web.Models.Extensions;

namespace SimonsVoss.SearchableFields.Web.Application;

public class SearchService : ISearchService
{
    private readonly IJsonDataImporter _jsonDataImporter;


    public SearchService(IJsonDataImporter jsonDataImporter)
    {
        _jsonDataImporter = jsonDataImporter;
    }

    public SearchResult Search(string textToSearch)
    {
        var jsonData = _jsonDataImporter.GetJsonData();

        var foundModels = new Dictionary<Guid, SearchableModel<Guid>>();

        CalculateTotalSearchingWeightOfGroups(foundModels, textToSearch, jsonData.Groups);

        CalculateTotalSearchingWeightOfMedias(foundModels, textToSearch, jsonData.Medias);

        CalculateTotalSearchingWeightOfBuildings(foundModels, textToSearch, jsonData.Buildings);

        CalculateTotalSearchingWeightOfLocks(foundModels, textToSearch, jsonData.Locks);

        return MapToSearchResult(foundModels, jsonData);
    }

    protected virtual SearchResult MapToSearchResult(Dictionary<Guid, SearchableModel<Guid>> foundModels,
        JsonData jsonData)
    {
        var foundModelIds = foundModels.Values
            .OrderByDescending(x => x.SearchingWeight)
            .Select(x => x.Id)
            .ToList();

        var groups = jsonData.Groups
            .Where(x => foundModelIds.Contains(x.Id))
            .ToList();

        var medias = jsonData.Medias
            .Where(x => foundModelIds.Contains(x.Id))
            .ToList();

        var buildings = jsonData.Buildings
            .Where(x => foundModelIds.Contains(x.Id))
            .ToList();

        var locks = jsonData.Locks
            .Where(x => foundModelIds.Contains(x.Id))
            .ToList();

        return new SearchResult
        {
            OrderedModelIds = foundModelIds,
            Groups = groups,
            Medias = medias,
            Buildings = buildings,
            Locks = locks
        };
    }

    protected virtual void CalculateTotalSearchingWeightOfGroups(
        Dictionary<Guid, SearchableModel<Guid>> foundModels,
        string textToSearch, List<GroupModel> groups)
    {
        foreach (var group in groups)
        {
            group.SearchingWeight = group.Calculate(textToSearch);

            if (group.SearchingWeight > 0)
            {
                foundModels.Add(group.Id, group);
            }
        }
    }

    protected virtual void CalculateTotalSearchingWeightOfMedias(
        Dictionary<Guid, SearchableModel<Guid>> foundModels,
        string textToSearch, List<MediaModel> medias)
    {
        foreach (var media in medias)
        {
            media.SearchingWeight = media.Calculate(textToSearch);

            if (!media.GroupId.HasValue || !foundModels.ContainsKey(media.GroupId.Value))
            {
                continue;
            }

            if (foundModels.ContainsKey(media.GroupId.Value))
            {
                var group = (GroupModel)foundModels[media.GroupId.Value];

                media.SearchingWeight += group.Calculate(textToSearch, true);
            }

            if (media.SearchingWeight > 0)
            {
                foundModels.Add(media.Id, media);
            }
        }
    }

    protected virtual void CalculateTotalSearchingWeightOfBuildings(
        Dictionary<Guid, SearchableModel<Guid>> foundModels,
        string textToSearch, List<BuildingModel> buildings)
    {
        foreach (var building in buildings)
        {
            building.SearchingWeight = building.Calculate(textToSearch);

            if (building.SearchingWeight > 0)
            {
                foundModels.Add(building.Id, building);
            }
        }
    }

    protected virtual void CalculateTotalSearchingWeightOfLocks(
        Dictionary<Guid, SearchableModel<Guid>> foundModels,
        string textToSearch, List<LockModel> locks)
    {
        foreach (var @lock in locks)
        {
            @lock.SearchingWeight = @lock.Calculate(textToSearch);

            if (!@lock.BuildingId.HasValue || !foundModels.ContainsKey(@lock.BuildingId.Value))
            {
                continue;
            }

            if (foundModels.ContainsKey(@lock.BuildingId.Value))
            {
                var building = (BuildingModel)foundModels[@lock.BuildingId.Value];

                @lock.SearchingWeight += building.Calculate(textToSearch, true);
            }

            if (@lock.SearchingWeight > 0)
            {
                foundModels.Add(@lock.Id, @lock);
            }
        }
    }
}