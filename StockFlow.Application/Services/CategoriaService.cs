using System;
using StockFlow.Application.DTOs;
using StockFlow.Application.Interfaces;
using StockFlow.Domain.Entities;
using StockFlow.Domain.Interfaces;

namespace StockFlow.Application.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _repository;

    CategoriaService(ICategoriaRepository categoriaRepository)
    {
        _repository = categoriaRepository;
    }

    public async Task<IEnumerable<CategoriaDto>> GetAllAsync()
    {
        var categorias = await _repository.GetAllAsync();
        return categorias.Select(MapToDto);
    }

    public async Task<CategoriaDto?> GetbyId(int id)
    {
        var categoria = await _repository.GetbyId(id);
        return categoria == null ? null : MapToDto(categoria);
    }

    public async Task<int> CountAsync()
    {
        return await _repository.CountAsync();
    }

    public async Task<CategoriaDto> AddAsync(CriarCategoriaDto dto)
    {
        var categoria = new Categoria
        {
            nome = dto.nome
        };

        await _repository.AddAsync(categoria);
        return MapToDto(categoria);
    }

    public async Task<CategoriaDto> UpdateAsync(int id, AtualizarCategoriaDto dto)
    {
        var cat = await _repository.GetbyId(id);
        if (cat == null) return null;

        cat.nome = dto.nome;

        await _repository.UpdateAsync(cat);
        return MapToDto(cat);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var cat = await _repository.GetbyId(id);
        if (cat == null)
        {
            return false;
        }

        await _repository.DeleteAsync(id);
        return true;
    }

    private static CategoriaDto MapToDto(Categoria categoria)
    {
        return new CategoriaDto
        {
            nome = categoria.nome
        };
    }
}
