using GoShop.Domain.Entities;
using GoShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoShop.Domain.Interfaces;

public interface IMobilePhoneHardwareService
{
    Task<List<MobilePhoneHardwareEntity>> GetAllAsync(MobilePhoneHardwareFiltersModel model, CancellationToken cancellationToken);

    Task<int> GetCountByFiltersAsync(MobilePhoneHardwareFiltersModel model, CancellationToken cancellationToken);
}