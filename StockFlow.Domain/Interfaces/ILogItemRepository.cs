using System;
using Microsoft.VisualBasic;
using StockFlow.Domain.Entities;

namespace StockFlow.Domain.Interfaces;

public interface ILogItemRepository
{
    Task<IEnumerable<LogItems>> GetAllAsync();
    Task<LogItems?> GetById(int id);
    Task<LogItems?> GetByItemAsync(int id);
    Task<LogItems?> GetByUserAsync(string nome);
    Task<bool> DeleteAsync(int id);
    Task  AddAsync(LogItems log);
}
