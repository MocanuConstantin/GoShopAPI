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

public class MobilePhoneHardwareRepository : IMobilePhoneHardwareRepository
{
    private readonly GoShopDbContext _context;

    public MobilePhoneHardwareRepository(GoShopDbContext context)
    {
        _context = context;
    }

    public async Task<List<MobilePhoneHardwareEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.MobilePhoneHardwareEntities
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<List<MobilePhoneHardwareEntity>> GetAllAsync(MobilePhoneHardwareFiltersModel model, CancellationToken cancellationToken)
    {
        var query = GetQueryByFilters(model);
        query = SortBy(query, model.SortBy?.ToLower() ?? "");

        return await query
            .AsNoTracking()
            .Skip(model.Offset ?? 0)
            .Take(model.Count ?? 150)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> GetCountByFiltersAsync(MobilePhoneHardwareFiltersModel filters, CancellationToken cancellationToken)
    {
        var query = GetQueryByFilters(filters);
        return await query.CountAsync(cancellationToken);
    }

    private IQueryable<MobilePhoneHardwareEntity> GetQueryByFilters(MobilePhoneHardwareFiltersModel filters)
    {
        var query = _context.MobilePhoneHardwareEntities.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filters.RAM))
        {
            query = query.Where(x => x.RAM.Contains(filters.RAM));
        }

        if (!string.IsNullOrWhiteSpace(filters.Storage))
        {
            query = query.Where(x => x.Storage.Contains(filters.Storage));
        }

        if (!string.IsNullOrWhiteSpace(filters.Display))
        {
            query = query.Where(x => x.Display.Contains(filters.Display));
        }

        if (!string.IsNullOrWhiteSpace(filters.Battery))
        {
            query = query.Where(x => x.Battery.Contains(filters.Battery));
        }

        if (!string.IsNullOrWhiteSpace(filters.Camera))
        {
            query = query.Where(x => x.Camera.Contains(filters.Camera));
        }

        if (!string.IsNullOrWhiteSpace(filters.Processor))
        {
            query = query.Where(x => x.Processor.Contains(filters.Processor));
        }

        return query;
    }

    private static IQueryable<MobilePhoneHardwareEntity> SortBy(IQueryable<MobilePhoneHardwareEntity> query, string sortBy)
    {
        return sortBy switch
        {
            "id-desc" => query.OrderByDescending(x => x.Id),
            "id-asc" => query.OrderBy(x => x.Id),
            "mobilephone-id-desc" => query.OrderByDescending(x => x.MobilePhoneId),
            "mobilephone-id-asc" => query.OrderBy(x => x.MobilePhoneId),
            "processor-desc" => query.OrderByDescending(x => x.Processor),
            "processor-asc" => query.OrderBy(x => x.Processor),
            "ram-desc" => query.OrderByDescending(x => x.RAM),
            "ram-asc" => query.OrderBy(x => x.RAM),
            "storage-desc" => query.OrderByDescending(x => x.Storage),
            "storage-asc" => query.OrderBy(x => x.Storage),
            "display-desc" => query.OrderByDescending(x => x.Display),
            "display-asc" => query.OrderBy(x => x.Display),
            "battery-desc" => query.OrderByDescending(x => x.Battery),
            "battery-asc" => query.OrderBy(x => x.Battery),
            "camera-desc" => query.OrderByDescending(x => x.Camera),
            "camera-asc" => query.OrderBy(x => x.Camera),
            "dimensions-desc" => query.OrderByDescending(x => x.Dimensions),
            "dimensions-asc" => query.OrderBy(x => x.Dimensions),
            "weight-desc" => query.OrderByDescending(x => x.Weight),
            "weight-asc" => query.OrderBy(x => x.Weight),
            _ => query.OrderByDescending(x => x.Id)
        };
    }
}
