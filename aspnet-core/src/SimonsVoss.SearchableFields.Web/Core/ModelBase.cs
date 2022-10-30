namespace SimonsVoss.SearchableFields.Web.Core;

public class ModelBase<TId>
{
    public TId Id { get; set; }

    public ModelBase()
    {
    }

    public ModelBase(TId id)
    {
        Id = id;
    }
}