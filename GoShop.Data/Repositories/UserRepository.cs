using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoShop.Domain.Entities;
using GoShop.Domain.Interfaces;
using GoShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace GoShop.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly GoShopDbContext _context;

    public UserRepository(GoShopDbContext context)
    { 
        _context = context; 
    }

    public async Task<List<UserEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.UserEntities
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<List<UserEntity>> GetAllAsync(UserFiltersModel model, CancellationToken cancellationToken)
    {
        var query = GetQueryByFilters(model);
        query = SortBy(query, model.SortBy?.ToLower() ?? "");

        return await query
            .AsNoTracking()
            .Skip(model.Offset ?? 0)
            .Take(model.Count ?? 150)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> GetCountByFiltersAsync(UserFiltersModel filters, CancellationToken cancellationToken)
    {
        var query = GetQueryByFilters(filters);
        return await query.CountAsync(cancellationToken);
    }

    private IQueryable<UserEntity> GetQueryByFilters(UserFiltersModel filters)
    {
        var query = _context.UserEntities.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filters.UserName))
        {
         query = query.Where(x => x.UserName.Contains(filters.UserName));
        }

        return query;
    }

    private static IQueryable<UserEntity> SortBy(IQueryable<UserEntity> query, string sortBy)
    {
        return sortBy switch
        {
            "id-desc" => query.OrderByDescending(x => x.Id),
            "id-asc" => query.OrderBy(x => x.Id),
            //"mobilephone-id-desc" => query.OrderByDescending(x => x.MobilePhoneId),
            //"mobilephone-id-asc" => query.OrderBy(x => x.MobilePhoneId),
            "email-desc" => query.OrderByDescending(x => x.Email),
            "email-asc" => query.OrderBy(x => x.Email),
            "username-desc" => query.OrderByDescending(x => x.UserName),
            "username-asc" => query.OrderBy(x => x.UserName),
            _ => query.OrderByDescending(x => x.Id)
        };
    }

    public async Task<UserEntity> CreateAsync(UserEntity user, CancellationToken cancellationToken)
    {
        UserEntity newUser = new UserEntity();
        newUser.UserName = user.UserName;
        newUser.Email = user.Email;
        newUser.Password = user.Password;
        newUser.MobilePhones = user.MobilePhones;

        await _context.UserEntities.AddAsync(newUser);

        await _context.SaveChangesAsync();

        return newUser;
    }
}
