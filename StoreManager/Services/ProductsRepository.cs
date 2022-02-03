using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreManager.Entities;

namespace StoreManager.Services;

public class ProductsRepository : IProductsRepository
{
    private readonly ApplicationDbContext _context = new ApplicationDbContext();

    public Task<List<Product>> GetProductsAsync()
    {
        return _context.Products.ToListAsync();
    }

    public Task<Product> GetProductAsync(int ProductId)
    {
        return _context.Products.FirstOrDefaultAsync(c => c.ProductId == ProductId);
    }

    public async Task<Product> AddProductAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        if (!_context.Products.Local.Any(c => c.ProductId == product.ProductId))
        {
            _context.Products.Attach(product);
        }
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return product;

    }

    public async Task DeleteProductAsync(int productId)
    {
        var product = _context.Products.FirstOrDefault(c => c.ProductId == productId);
        if (product != null)
        {
            _context.Products.Remove(product);
        }
        await _context.SaveChangesAsync();
    }
}