using System;
using Microsoft.EntityFrameworkCore;
using StockFlow.Domain.Entities;
using StockFlow.Domain.Interfaces;
using StockFlow.Infraestructure.Context;

namespace StockFlow.Infraestructure.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly StockDbContext _context;

    public ItemRepository(StockDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Item>> GetAllAsync()
    {
        return await _context.Item.ToListAsync();
    }

    public async Task<Item> GetByIdAsync(int Id)
    {
        return await _context.Item.FirstOrDefaultAsync(i => i.id == Id);
    }

    public async Task<int> CountAsync()
    {
        return await _context.Item.CountAsync();
    }

    public async Task AddAsync(Item item)
    {
        await _context.Item.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Item item)
    {
        _context.Item.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await _context.Item.FindAsync(id);
        if (item != null)
        {
            _context.Item.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
