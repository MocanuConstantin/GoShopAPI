using GoShop.Domain.Entities;
using GoShop.Domain.Models;

namespace GoShop.Domain.Interfaces;

public interface IMobilePhoneSoftwareRepository
{
    Task<List<MobilePhoneSoftwareEntity>> GetAllAsync(MobilePhoneSoftwareFiltersModel model, CancellationToken cancellationToken);

    Task<int> GetCountByFiltersAsync(MobilePhoneSoftwareFiltersModel model, CancellationToken cancellationToken);
}