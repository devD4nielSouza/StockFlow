using System;

namespace StockFlow.Domain.Entities;

public class Item
{
    public string nome {get;set;} = string.Empty;
    public string descrição {get;set;} = string.Empty;
    public int estoque {get;set;}
    public decimal preço {get;set;}
    public Categoria? Categoria {get;set;}
}
