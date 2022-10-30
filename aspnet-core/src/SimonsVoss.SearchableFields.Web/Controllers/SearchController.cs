using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SimonsVoss.SearchableFields.Web.Application;

namespace SimonsVoss.SearchableFields.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchController : ControllerBase
{
    private readonly ISearchService _searchService;

    public SearchController(ISearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpGet]
    public IActionResult Search(string textToSearch)
    {
        if (string.IsNullOrEmpty(textToSearch))
        {
            return NotFound();
        }
        
        var searchResult = _searchService.Search(textToSearch);
        
        return Ok(searchResult);
    }
}