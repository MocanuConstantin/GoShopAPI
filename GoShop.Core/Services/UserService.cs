using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoShop.Domain.Entities;
using GoShop.Domain.Interfaces;
using GoShop.Domain.Models;
using Microsoft.Extensions.Logging;

namespace GoShop.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly ILogger<UserService> _logger;
    public UserService(IUserRepository repository, ILogger<UserService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<UserEntity> CreateUserAsync(UserEntity entity, CancellationToken cancellationToken)
    {
        try
        {
            return await _repository.CreateAsync(entity, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed create user");
            return null;
        }
    }

    public async Task<List<UserEntity>> GetAllAsync(UserFiltersModel model, CancellationToken cancellationToken = default)
    {
        try
        {
            return await _repository.GetAllAsync(model, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get all UserEntities");
            return new List<UserEntity>();
        }
    }

    public async Task<int> GetCountByFiltersAsync(UserFiltersModel model, CancellationToken cancellationToken = default)
    {
        try
        {
            return await _repository.GetCountByFiltersAsync(model, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get count by filters for UserEntities");
            return 0;
        }
    }
}