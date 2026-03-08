using System.Security.Cryptography.X509Certificates;

namespace ECommerceProductCatalog.Domain.Entities;

public class Base
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdatedDate { get; set; }
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }
}