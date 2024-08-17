using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoShop.Domain.Models;

public class UserFiltersModel
{
    public int? Count { get; set; }
    public int? Offset { get; set; }
    public string? SortBy { get; set; }
    public string? UserName { get; set; } 
}
