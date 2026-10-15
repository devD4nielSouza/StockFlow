using System;

namespace StockFlow.Domain.Entities;

public class Item
{
    public  int id {get;set;}
    public string nome {get;set;} = string.Empty;
    public string descricao {get;set;} = string.Empty;
    public int estoque {get;set;}
    public decimal preco {get;set;}
    public Categoria? Categoria {get;set;}
}
