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

public class MobilePhoneSoftwareRepository : IMobilePhoneSoftwareRepository
{
    private readonly GoShopDbContext _context;
      
    public MobilePhoneSoftwareRepository(GoShopDbContext context)
    {
        _context = context;
    }

    public async Task<List<MobilePhoneSoftwareEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.MobilePhoneSoftwareEntities
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<List<MobilePhoneSoftwareEntity>> GetAllAsync(MobilePhoneSoftwareFiltersModel model, CancellationToken cancellationToken)
    {
        var query = GetQueryByFilters(model);
        query = SortBy(query, model.SortBy?.ToLower() ?? "");

        return await query
            .AsNoTracking()
            .Skip(model.Offset ?? 0)
            .Take(model.Count ?? 150)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> GetCountByFiltersAsync(MobilePhoneSoftwareFiltersModel filters, CancellationToken cancellationToken)
    {
        var query = GetQueryByFilters(filters);
        return await query.CountAsync(cancellationToken);
    }

    private IQueryable<MobilePhoneSoftwareEntity> GetQueryByFilters(MobilePhoneSoftwareFiltersModel filters)
    {
        var query = _context.MobilePhoneSoftwareEntities.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filters.OperatingSystem))
        {
            query = query.Where(x => x.OperatingSystem.Contains(filters.OperatingSystem));
        }

        if (!string.IsNullOrWhiteSpace(filters.OSVersion))
        {
            query = query.Where(x => x.OSVersion.Contains(filters.OSVersion));
        }

        if (!string.IsNullOrWhiteSpace(filters.FirmwareVersion))
        {
            query = query.Where(x => x.FirmwareVersion.Contains(filters.FirmwareVersion));
        }

        if (filters.IsRootedOrJailbroken.HasValue)
        {
            query = query.Where(x => x.IsRootedOrJailbroken == filters.IsRootedOrJailbroken.Value);
        }

        return query;
    }

    private static IQueryable<MobilePhoneSoftwareEntity> SortBy(IQueryable<MobilePhoneSoftwareEntity> query, string sortBy)
    {
        return sortBy switch
        {
            "id-desc" => query.OrderByDescending(x => x.Id),
            "id-asc" => query.OrderBy(x => x.Id),
            //"mobilephone-id-desc" => query.OrderByDescending(x => x.MobilePhoneID),
            //"mobilephone-id-asc" => query.OrderBy(x => x.MobilePhoneID),
            "operatingsystem-desc" => query.OrderByDescending(x => x.OperatingSystem),
            "operatingsystem-asc" => query.OrderBy(x => x.OperatingSystem),
            "osversion-desc" => query.OrderByDescending(x => x.OSVersion),
            "osversion-asc" => query.OrderBy(x => x.OSVersion),
            "firmareversion-desc" => query.OrderByDescending(x => x.FirmwareVersion),
            "firmareversion-asc" => query.OrderBy(x => x.FirmwareVersion),
            "isRootedOrJailbroken-desc" => query.OrderByDescending(x => x.IsRootedOrJailbroken),
            "isRootedOrJailbroken-asc" => query.OrderBy(x => x.IsRootedOrJailbroken),
            "lastSoftwareUpdate-desc" => query.OrderByDescending(x => x.LastSoftwareUpdate),
            "lastSoftwareUpdate-asc" => query.OrderBy(x => x.LastSoftwareUpdate),
            _ => query.OrderByDescending(x => x.Id)
        };
    }
}
