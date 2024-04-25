using System.Text.Json.Serialization;

namespace RentMyCycler.Api.DTO;

public abstract class DtoBase
{
    [JsonIgnore]
    
    public int id { get; set; }
}