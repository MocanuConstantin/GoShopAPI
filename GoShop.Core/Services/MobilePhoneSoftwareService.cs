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

public class MobilePhoneSoftwareService : IMobilePhoneSoftwareService
{
    private readonly IMobilePhoneSoftwareRepository _repository;
    private readonly ILogger<MobilePhoneSoftwareService> _logger;
    public MobilePhoneSoftwareService(IMobilePhoneSoftwareRepository repository, ILogger<MobilePhoneSoftwareService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<List<MobilePhoneSoftwareEntity>> GetAllAsync(MobilePhoneSoftwareFiltersModel model, CancellationToken cancellationToken = default)
    {
        try
        {
            return await _repository.GetAllAsync(model, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get all MobilePhoneSoftwareEntities");
            return new List<MobilePhoneSoftwareEntity>();
        }
    }

    public async Task<int> GetCountByFiltersAsync(MobilePhoneSoftwareFiltersModel model, CancellationToken cancellationToken = default)
    {
        try
        {
            return await _repository.GetCountByFiltersAsync(model, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get count by filters for MobilePhoneSoftwareEntities");
            return 0;
        }
    }
}