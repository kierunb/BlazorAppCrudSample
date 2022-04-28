using System.ComponentModel.DataAnnotations;

namespace BlazorAppCrudDorota.Shared.ViewModels;

public class OrderView
{
    public int OrderId { get; set; }
    public decimal? Freight { get; set; }

    [Required]
    [StringLength(10, ErrorMessage = "Name is too long.")]
    public string ShipName { get; set; }
    public string ShipAddress { get; set; }
    public string ShipCity { get; set; }
    public string ShipRegion { get; set; }
    public string ShipPostalCode { get; set; }
    public string ShipCountry { get; set; }
}
