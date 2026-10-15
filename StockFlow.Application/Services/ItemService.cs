using System;
using StockFlow.Application.DTOs;
using StockFlow.Application.Interfaces;
using StockFlow.Domain.Entities;
using StockFlow.Domain.Interfaces;

namespace StockFlow.Application.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _repository;

    public ItemService(IItemRepository itemRepository)
    {
        _repository = itemRepository;
    }

    public async Task<IEnumerable<ItemDto>> GetAllAsync()
    {
        var items = await _repository.GetAllAsync();
        return items.Select(MapToDto);
    }

    public async Task<ItemDto?> GetByIdAsync(int id)
    {
        var item = await _repository.GetByIdAsync(id);
        return item == null ? null : MapToDto(item);
    }

    public async Task<ItemDto> AddAsync(CriarItemDto dto)
    {
        var item = new Item
        {
            nome = dto.nome,
            descricao = dto.descricao,
            estoque = dto.estoque,
            preco = dto.preco
        };

        await _repository.AddAsync(item);

        return MapToDto(item);
    }

    public  async Task<ItemDto> UpdateAsync(int id, AtualizarItemDto dto)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item == null) return null;

        item.nome = dto.nome;
        item.descricao = dto.descricao;
        item.estoque = dto.estoque;
        item.preco = dto.preco;

        await _repository.UpdateAsync(item);
        return MapToDto(item);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item == null)
        {
            return false;
        }

        await _repository.DeleteAsync(id);
        return true;
    }
    
    public async Task<int> CountAsync()
    {
      return await _repository.CountAsync();
    }

    private static ItemDto MapToDto(Item item)
    {
        return new ItemDto
        {
            id = item.id,
            nome = item.nome,
            descricao = item.descricao,
            estoque = item.estoque,
            preco = item.preco
        };
    }

}
