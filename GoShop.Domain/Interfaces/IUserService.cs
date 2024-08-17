using GoShop.Domain.Entities;
using GoShop.Domain.Models;

namespace GoShop.Domain.Interfaces;

public interface IUserService
{
    Task<List<UserEntity>> GetAllAsync(UserFiltersModel model, CancellationToken cancellationToken);

    Task<int> GetCountByFiltersAsync(UserFiltersModel model, CancellationToken cancellationToken);

    Task<UserEntity> CreateUserAsync(UserEntity mobilePhoneDto, CancellationToken cancellationToken);
}