using SimonsVoss.SearchableFields.Web.Core;

namespace SimonsVoss.SearchableFields.Web.Models;

public class LockModel : SearchableModel<Guid>
{
    public string Type { get; set; }
    public string Name { get; set; }
    public string SerialNumber { get; set; }
    public string Floor { get; set; }
    public string RoomNumber { get; set; }
    public string Description { get; set; }
    
    public Guid? BuildingId { get; set; }
    public BuildingModel Building { get; set; }

    public override string ModelType => "Lock";
}