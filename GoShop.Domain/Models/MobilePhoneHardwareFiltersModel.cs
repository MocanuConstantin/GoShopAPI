using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoShop.Domain.Models;

public class MobilePhoneHardwareFiltersModel
{
    public int? Count { get; set; }
    public int? Offset { get; set; }
    public string? SortBy { get; set; }
    public string? Processor { get; set; }
    public string? RAM { get; set; }
    public string? Storage { get; set; } 
    public string? Display { get; set; } 
    public string? Battery { get; set; } 
    public string? Camera { get; set; }
}
