using System;
using StockFlow.Domain.Entities;

namespace StockFlow.Domain.Interfaces;

public interface ICategoriaRepository
{
    Task<IEnumerable<Categoria>> GetAllAsync();
    Task<Categoria?>  GetbyId(int id);
    Task<int> CountAsync();
    Task AddAsync(Categoria categoria);
    Task UpdateAsync(Categoria categoria);
    Task DeleteAsync(int id);
}
