using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoShop.Data.Repositories;
using GoShop.Domain.Entities;
using GoShop.Domain.Interfaces;
using GoShop.Domain.Models;
using Microsoft.Extensions.Logging;

namespace GoShop.Core.Services;

public class MobilePhoneHardwareService : IMobilePhoneHardwareService
{
    private readonly IMobilePhoneHardwareRepository _repository;
    private readonly ILogger<MobilePhoneHardwareService> _logger;
    public MobilePhoneHardwareService(IMobilePhoneHardwareRepository repository, ILogger<MobilePhoneHardwareService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<List<MobilePhoneHardwareEntity>> GetAllAsync(MobilePhoneHardwareFiltersModel model, CancellationToken cancellationToken=default)
    {
        try
        {
            return await _repository.GetAllAsync(model, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get all MobilePhoneHardwareEntities");
            return new List<MobilePhoneHardwareEntity>();
        }
    }

    public async Task<int> GetCountByFiltersAsync(MobilePhoneHardwareFiltersModel model, CancellationToken cancellationToken = default)
    {
        try
        {
            return await _repository.GetCountByFiltersAsync(model, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get count by filters for MobilePhoneHardwareEntities");
            return 0;
        }
    }
}
