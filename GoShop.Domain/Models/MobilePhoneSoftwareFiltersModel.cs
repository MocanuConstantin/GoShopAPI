using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoShop.Domain.Models;

public class MobilePhoneSoftwareFiltersModel
{
    public int? Count { get; set; }
    public int? Offset { get; set; }
    public string? SortBy { get; set; }
    public string? OperatingSystem { get; set; } 
    public string? OSVersion { get; set; } 
    public string? FirmwareVersion { get; set; }
    public bool? IsRootedOrJailbroken { get; set; }
}
