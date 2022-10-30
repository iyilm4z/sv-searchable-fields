namespace SimonsVoss.SearchableFields.Web.Core;

public abstract class SearchableModel<TId> : ModelBase<TId>
{
    public int SearchingWeight { get; set; }

    public abstract string ModelType { get; }
}