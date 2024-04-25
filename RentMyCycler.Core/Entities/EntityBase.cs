namespace Tecnm.Ecommerce.Core.Entities;

public abstract class EntityBase
{
    public int id { get; set; }
    public bool isDeleted { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public  string UpdatedBy { get; set; }
    public DateTime UpdatedDate { get; set; }
}