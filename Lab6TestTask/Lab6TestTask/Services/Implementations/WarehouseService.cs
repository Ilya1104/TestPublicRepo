using Lab6TestTask.Data;
using Lab6TestTask.Enums;
using Lab6TestTask.Models;
using Lab6TestTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab6TestTask.Services.Implementations;

/// <summary>
/// WarehouseService.
/// Implement methods here.
/// </summary>
public class WarehouseWithTotal
{
    public Warehouse Warehouse { get; set; }

public decimal CommonSum { get; set; }
}
public class WarehouseService : IWarehouseService
{
    private readonly ApplicationDbContext _dbContext;

    public WarehouseService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Warehouse> GetWarehouseAsync()
    {
        //i have a few implementations but because i can change only 2 files,
        //and i cant create property like "CommonSum"
        //i cant display the total sum of products in the warehouse :(
        

        var warehouses = await _dbContext.Warehouses
      .Where(w => w.Products.Any(p => p.Status == ProductStatus.ReadyForDistribution))
      .OrderByDescending(w => w.Products.Where(p => p.Status == ProductStatus.ReadyForDistribution).Sum(p => p.Price))
      .ToListAsync();

        return warehouses.FirstOrDefault();
    }

    public async Task<IEnumerable<Warehouse>> GetWarehousesAsync()
    {
        var startDate = new DateTime(2025, 4, 1);
        var endDate = new DateTime(2025, 6, 30); var result = await _dbContext.Warehouses
        .Include(w => w.Products)
        .Where(w => w.Products.Any(p =>
            p.ReceivedDate >= startDate &&
            p.ReceivedDate <= endDate))
        .Select(w => new Warehouse
        {
            WarehouseId = w.WarehouseId,
            Name = w.Name,
            Location = w.Location,
            Products = w.Products
                .Where(p => p.ReceivedDate >= startDate &&
                           p.ReceivedDate <= endDate)
                .ToList()
        })
        .ToListAsync();
        return result;
    }
}
