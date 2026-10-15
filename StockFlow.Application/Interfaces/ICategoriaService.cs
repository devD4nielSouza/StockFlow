using System;
using StockFlow.Application.DTOs;

namespace StockFlow.Application.Interfaces;

public interface ICategoriaService
{
    Task<IEnumerable<CategoriaDto>> GetAllAsync();
    Task<CategoriaDto?>  GetbyId(int id);
    Task<int> CountAsync();
    Task<CategoriaDto> AddAsync(CriarCategoriaDto categoria);
    Task<CategoriaDto> UpdateAsync(int id,AtualizarCategoriaDto categoria);
    Task<bool> DeleteAsync(int id);
}
