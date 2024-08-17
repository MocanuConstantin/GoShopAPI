using GoShop.Domain.Interfaces;
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

public class MobilePhoneService : IMobilePhoneService
{
    private readonly IMobilePhoneRepository _repository;
    private readonly ILogger<MobilePhoneService> _logger;
    public MobilePhoneService(IMobilePhoneRepository repository, ILogger<MobilePhoneService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<List<MobilePhoneEntity>> GetAllAsync(MobilePhoneFiltersModel model, CancellationToken cancellationToken = default)
    {
        try
        {
            return await _repository.GetAllAsync(model, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get all MobilePhoneEntities");
            return new List<MobilePhoneEntity>();
        }
    }

    public async Task<int> GetCountByFiltersAsync(MobilePhoneFiltersModel model, CancellationToken cancellationToken = default)
    {
        try
        {
            return await _repository.GetCountByFiltersAsync(model, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get count by filters for MobilePhoneEntities");
            return 0;
        }
    }

    public async Task<MobilePhoneEntity> CreateAsync(MobilePhoneEntity entity, CancellationToken cancellationToken)
    {
        try
        {
            return await _repository.CreateMobilePhoneAsync(entity, cancellationToken);
        }
        catch(Exception ex) 
        {
           _logger.LogError(ex, "Failed to create entity");
            throw;
        }
    }
}