using GoShop.Domain.Models;

namespace GoShop.Domain.Interfaces;

public interface IMobilePhoneService
{
    Task<List<MobilePhoneEntity>> GetAllAsync(MobilePhoneFiltersModel model, CancellationToken cancellationToken);

    Task<int> GetCountByFiltersAsync(MobilePhoneFiltersModel model, CancellationToken cancellationToken);

    Task<MobilePhoneEntity> CreateAsync(MobilePhoneEntity mobilePhoneDto, CancellationToken cancellationToken);
}