using System;
using Microsoft.EntityFrameworkCore;
using StockFlow.Domain.Entities;
using StockFlow.Domain.Interfaces;
using StockFlow.Infraestructure.Context;

namespace StockFlow.Infraestructure.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    // Campo privado que armazena a instância do DbContext
    private readonly StockDbContext _context;

    // Construtor do repositório de categorias
    public CategoriaRepository(StockDbContext context)
    {
        // Recebe o DbContext via injeção de dependência
        // e atribui ao campo privado para uso nos métodos da classe
        _context = context;
    }

    // Método responsável por buscar todas as categorias cadastradas no banco de dados
    public async Task<IEnumerable<Categoria>> GetAllAsync()
    {
        // Acessa a tabela de categorias
        return await _context.Categoria
            .Include(c => c.Items) // Carrega também os produtos relacionados a cada categoria
            .OrderBy(c => c.nome)  // Ordena as categorias em ordem alfabética pelo nome
            .ToListAsync(); // Executa a consulta e retorna o resultado como uma lista assíncrona
    }

    // Método responsável por buscar uma categoria específica pelo seu ID
    public async Task<Categoria?> GetbyId(int id)
    {
        return await _context.Categoria
            .Include(c => c.Items)  // Carrega também os produtos relacionados à categoria
            .FirstOrDefaultAsync(c => c.id == id); // Procura a primeira categoria que possui o ID informado
                                                   // Retorna null caso não encontre nenhuma categoria
    }

    // Método responsável por cadastrar uma nova categoria no banco de dados
    public async Task AddAsync(Categoria categoria)
    {
        await _context.Categoria.AddAsync(categoria); // Adiciona a categoria recebida ao DbSet Categories
        await _context.SaveChangesAsync(); // Persiste as alterações no banco de dados
    }

    // Método responsável por atualizar uma categoria existente no banco de dados
    public async Task UpdateAsync(Categoria categoria)
    {
        _context.Categoria.Update(categoria);  // Marca a entidade como modificada no contexto do Entity Framework
        await _context.SaveChangesAsync(); // Salva as alterações realizadas no banco de dados
    }

    // Método responsável por remover uma categoria do banco de dados pelo ID
    public async Task DeleteAsync(int id)
    {
        var categoria = await _context.Categoria.FindAsync(id);  // Busca a categoria pelo ID no banco de dados

        if (categoria != null) // Verifica se a categoria existe antes de tentar remover
        {
            _context.Categoria.Remove(categoria); // Remove a entidade do contexto do Entity Framework
            await _context.SaveChangesAsync(); // Persiste a exclusão no banco de dados
        }
    }

    // Método responsável por contar o total de categorias no banco de dados
    public async Task<int> CountAsync()
    {
        return await _context.Categoria.CountAsync(); // Executa uma contagem diretamente no banco de dados
    }
}
