namespace SimonsVoss.SearchableFields.Web.Application;

public interface ISearchService 
{
    SearchResult Search(string textToSearch);
}