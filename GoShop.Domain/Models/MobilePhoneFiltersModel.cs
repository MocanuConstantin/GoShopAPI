using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoShop.Domain.Models;

public class MobilePhoneFiltersModel
{
    public int? Count { get; set; }
    public int? Offset { get; set; }
    public string? SortBy { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public int? YearFrom { get; set; }
    public int? YearTo { get; set; }
    public decimal? PriceFrom { get; set; } = 0;
    public decimal? PriceTo { get; set; } = 0;
}
