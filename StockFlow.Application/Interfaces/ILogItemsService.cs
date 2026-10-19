using System;
using Microsoft.VisualBasic;
using StockFlow.Application.DTOs;

namespace StockFlow.Application.Interfaces;

public interface ILogItemService
{
    Task<IEnumerable<LogItemsDto>> GetAllAsync();
    Task<LogItemsDto?> GetById(int id);
    Task<LogItemsDto?> GetByItemAsync(int id);
    Task<LogItemsDto?> GetByUserAsync(string nome);
    Task<bool> DeleteAsync(int id);
    Task<LogItemsDto> AddAsync(CriarLogItemDto log);
}
