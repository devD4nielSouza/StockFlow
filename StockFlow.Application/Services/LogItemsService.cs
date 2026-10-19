using System;
using StockFlow.Application.DTOs;
using StockFlow.Application.Interfaces;
using StockFlow.Domain.Entities;
using StockFlow.Domain.Interfaces;

namespace StockFlow.Application.Services;

public class LogItemsService : ILogItemService
{
    private readonly ILogItemRepository _repository;

    public LogItemsService(ILogItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<LogItemsDto>> GetAllAsync()
    {
        var logs = await _repository.GetAllAsync();
        return logs.Select(MapToDto);
    }

    public async Task<LogItemsDto?> GetByItemAsync(int id)
    {
        var log = await _repository.GetByItemAsync(id);
        return log == null ? null : MapToDto(log);
    }

    public async Task<LogItemsDto?> GetByUserAsync(string nome)
    {
        var log = await _repository.GetByUserAsync(nome);
        return log == null ? null : MapToDto(log);
    }

    public async Task<LogItemsDto?> GetById(int id)
    {
        var log = await _repository.GetById(id);
        return log == null ? null : MapToDto(log);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var log = await _repository.GetById(id);
        if (log == null)
        {
            return false;
        }

        await _repository.DeleteAsync(id);
        return true;
    }

    public async Task<LogItemsDto> AddAsync(CriarLogItemDto dto)
    {
        var log  = new LogItems
        {
          userId = dto.userId,
          itemId = dto.itemId,
        };

        await _repository.AddAsync(log);
        return MapToDto(log);
    }

    private static LogItemsDto MapToDto(LogItems log)
    {
        return new LogItemsDto
        {
            id = log.id,
            itemId = log.itemId,
            userId = log.userId,
            modificadoEm = log.modificadoEm
        };
    }
}
