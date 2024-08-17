using GoShop.Domain.Entities;
using GoShop.Domain.Models;

namespace GoShop.Domain.Interfaces;

public interface IMobilePhoneHardwareRepository
{
    Task<List<MobilePhoneHardwareEntity>> GetAllAsync(MobilePhoneHardwareFiltersModel model, CancellationToken cancellationToken);

    Task<int> GetCountByFiltersAsync(MobilePhoneHardwareFiltersModel model, CancellationToken cancellationToken);
}