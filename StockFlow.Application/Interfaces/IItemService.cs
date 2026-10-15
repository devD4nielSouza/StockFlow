using System;
using StockFlow.Application.DTOs;

namespace StockFlow.Application.Interfaces;

public interface IItemService
{
    Task<IEnumerable<ItemDto>> GetAllAsync();
    Task<ItemDto?> GetByIdAsync(int id);
    Task<int> CountAsync();
    Task<ItemDto> AddAsync (CriarItemDto item);
    Task<ItemDto> UpdateAsync (int id , AtualizarItemDto item);
    Task<bool> DeleteAsync (int id);
}
