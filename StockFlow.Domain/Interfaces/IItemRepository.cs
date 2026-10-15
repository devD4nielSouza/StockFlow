using System;
using StockFlow.Domain.Entities;

namespace StockFlow.Domain.Interfaces;

public interface IItemRepository
{
    Task<IEnumerable<Item>> GetAllAsync();
    Task<Item?> GetByIdAsync(int id);
    Task<int> CountAsync();
    Task AddAsync(Item item);
    Task UpdateAsync(Item item);
    Task DeleteAsync(int id);
}
