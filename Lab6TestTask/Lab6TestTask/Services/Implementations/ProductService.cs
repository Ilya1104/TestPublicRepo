using Lab6TestTask.Data;
using Lab6TestTask.Models;
using Lab6TestTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab6TestTask.Services.Implementations;

/// <summary>
/// ProductService.
/// Implement methods here.
/// </summary>
public class ProductService : IProductService
{
    private readonly ApplicationDbContext _dbContext;

    public ProductService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> GetProductAsync()
    {
        var productEntity = await _dbContext.Products.Select(item => new Product
        {
            Name = item.Name,
            Quantity = item.Quantity,
            Status = item.Status,
            ReceivedDate = item.ReceivedDate,
            Price = item.Price
        }) .OrderByDescending(p => p.Price).Where(x => x.Status == Enums.ProductStatus.Reserved).FirstAsync();

        return productEntity;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        var productEntities = await _dbContext.Products.Select(item => new Product
        {
            Name = item.Name,
            Quantity = item.Quantity,
            Status = item.Status,
            ReceivedDate = item.ReceivedDate,
            Price = item.Price
        }).Where(x => x.Quantity > 1000 && x.ReceivedDate.Year == 2025).ToListAsync();

        return productEntities; 
    
    }
}
