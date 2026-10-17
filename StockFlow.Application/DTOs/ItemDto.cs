using System;

namespace StockFlow.Application.DTOs;

public class ItemDto
{
    public  int id {get;set;}
    public string nome {get;set;} = string.Empty;
    public int idCategoria {get;set;}
    public string descricao {get;set;} = string.Empty;
    public int estoque {get;set;}
    public decimal preco {get;set;}
}

public class CriarItemDto
{
    public string nome {get;set;} = string.Empty;
    public string descricao {get;set;} = string.Empty;
    public int idCategoria {get;set;}
    public int estoque {get;set;}
    public decimal preco {get;set;}
}

public class AtualizarItemDto
{
    public string nome {get;set;} = string.Empty;
    public string descricao {get;set;} = string.Empty;
    public int idCategoria {get;set;}
    public int estoque {get;set;}
    public decimal preco {get;set;}
}