using GoShop.Domain.Entities;
using GoShop.Domain.Models;

namespace GoShop.Domain.Interfaces;

public interface IUserRepository
{
    Task<List<UserEntity>> GetAllAsync(UserFiltersModel model, CancellationToken cancellationToken);

    Task<int> GetCountByFiltersAsync(UserFiltersModel model, CancellationToken cancellationToken);

    Task<UserEntity> CreateAsync(UserEntity mobilePhoneDto, CancellationToken cancellationToken);
}