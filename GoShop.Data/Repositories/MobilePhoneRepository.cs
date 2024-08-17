using GoShop.Domain.Entities;
using GoShop.Domain.Interfaces;
using GoShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoShop.Data.Repositories;

public class MobilePhoneRepository : IMobilePhoneRepository
{
    private readonly GoShopDbContext _context;

    public MobilePhoneRepository(GoShopDbContext context)
    {
        _context = context;
    }

    public async Task<List<MobilePhoneEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.MobilePhoneEntities
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<List<MobilePhoneEntity>> GetAllAsync(MobilePhoneFiltersModel model, CancellationToken cancellationToken)
    {
        var query = GetQueryByFilters(model);
        query = SortBy(query, model.SortBy?.ToLower() ?? "");

        return await query
            .AsNoTracking()
            .Skip(model.Offset ?? 0)
            .Take(model.Count ?? 150)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> GetCountByFiltersAsync(MobilePhoneFiltersModel filters, CancellationToken cancellationToken)
    {
        var query = GetQueryByFilters(filters);
        return await query.CountAsync(cancellationToken);
    }

    public async Task<MobilePhoneEntity> CreateMobilePhoneAsync(MobilePhoneEntity mobilePhoneEntity, CancellationToken cancellationToken)
    {

        var result = new MobilePhoneEntity();

        result.Id = mobilePhoneEntity.Id;
        result.Brand = mobilePhoneEntity.Brand;
        result.Model = mobilePhoneEntity.Model;
        result.Year = mobilePhoneEntity.Year;
        result.Condition = mobilePhoneEntity.Condition;
        result.Description = mobilePhoneEntity.Description;
        result.Price = mobilePhoneEntity.Price;

        result.MobilePhoneHardware = new MobilePhoneHardwareEntity
        {
            Id = Guid.NewGuid(),
            Processor = mobilePhoneEntity.MobilePhoneHardware.Processor,
            RAM = mobilePhoneEntity.MobilePhoneHardware.RAM,
            Storage = mobilePhoneEntity.MobilePhoneHardware.Storage,
            Display = mobilePhoneEntity.MobilePhoneHardware.Display,
            Battery = mobilePhoneEntity.MobilePhoneHardware.Battery,
            Camera = mobilePhoneEntity.MobilePhoneHardware.Camera,
            Dimensions = mobilePhoneEntity.MobilePhoneHardware.Dimensions,
            Weight = mobilePhoneEntity.MobilePhoneHardware.Weight,
            MobilePhoneId = result.Id,
            MobilePhone = result
        };

        result.MobilePhoneSoftware = new MobilePhoneSoftwareEntity
        {
            Id = Guid.NewGuid(),
            OperatingSystem = mobilePhoneEntity.MobilePhoneSoftware.OperatingSystem,
            OSVersion = mobilePhoneEntity.MobilePhoneSoftware.OSVersion,
            FirmwareVersion = mobilePhoneEntity.MobilePhoneSoftware.FirmwareVersion,
            IsRootedOrJailbroken = mobilePhoneEntity.MobilePhoneSoftware.IsRootedOrJailbroken,
            LastSoftwareUpdate = mobilePhoneEntity.MobilePhoneSoftware.LastSoftwareUpdate,
            MobilePhoneId = result.Id,
            MobilePhone = result
        };

        await _context.MobilePhoneEntities.AddAsync(result, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return result;
    }

    private IQueryable<MobilePhoneEntity> GetQueryByFilters(MobilePhoneFiltersModel filters)
    {
        var query = _context.MobilePhoneEntities.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filters.Brand))
        {
            query = query.Where(x => x.Brand.Contains(filters.Brand));
        }

        if (!string.IsNullOrWhiteSpace(filters.Model))
        {
            query = query.Where(x => x.Model.Contains(filters.Model));
        }

        if (filters.YearTo.HasValue)
        {
            query = query.Where(x => x.Year >= filters.YearFrom);
        }

        if (filters.YearTo.HasValue)
        {
            query = query.Where(x => x.Year <= filters.YearTo);
        }

        if (filters.PriceFrom.HasValue)
        {
            query = query.Where(x => x.Price >= filters.PriceFrom);
        }

        if (filters.PriceTo.HasValue)
        {
            query = query.Where(x => x.Price <= filters.PriceTo);
        }

        return query;
    }

    private static IQueryable<MobilePhoneEntity> SortBy(IQueryable<MobilePhoneEntity> query, string sortBy)
    {
        return sortBy switch
        {
            "id-desc" => query.OrderByDescending(x => x.Id),
            "id-asc" => query.OrderBy(x => x.Id),
            //"user-id-desc" => query.OrderByDescending(x => x.UserId),
            //"user-id-asc" => query.OrderBy(x => x.UserId),
            //"mobilephonehardware-id-desc" => query.OrderByDescending(x => x.MobilePhoneHardwareId),
            //"mobilephonehardware-id-asc" => query.OrderBy(x => x.MobilePhoneHardwareId),
            //"mobilephonesoftware-id-desc" => query.OrderByDescending(x => x.MobilePhoneSoftwareId),
            //"mobilephonesoftware-id-asc" => query.OrderBy(x => x.MobilePhoneSoftwareId),
            "brand-desc" => query.OrderByDescending(x => x.Brand),
            "brand-asc" => query.OrderBy(x => x.Brand),
            "model-desc" => query.OrderByDescending(x => x.Model),
            "model-asc" => query.OrderBy(x => x.Model),
            "year-desc" => query.OrderByDescending(x => x.Year),
            "year-asc" => query.OrderBy(x => x.Year),
            "condition-desc" => query.OrderByDescending(x => x.Condition),
            "condition-asc" => query.OrderBy(x => x.Condition),
            "description-desc" => query.OrderByDescending(x => x.Description),
            "description-asc" => query.OrderBy(x => x.Description),
            "price-desc" => query.OrderByDescending(x => x.Price),
            "price-asc" => query.OrderBy(x => x.Price),
            _ => query.OrderByDescending(x => x.Id)
        };
    }
}
