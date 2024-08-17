using GoShop.Domain.Entities;
using GoShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoShop.Domain.Interfaces;

public interface IMobilePhoneSoftwareService
{
    Task<List<MobilePhoneSoftwareEntity>> GetAllAsync(MobilePhoneSoftwareFiltersModel model, CancellationToken cancellationToken);

    Task<int> GetCountByFiltersAsync(MobilePhoneSoftwareFiltersModel model, CancellationToken cancellationToken);
}