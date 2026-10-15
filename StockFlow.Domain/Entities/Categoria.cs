using System;

namespace StockFlow.Domain.Entities;

public class Categoria
{
    public string nome {get;set;} = string.Empty;
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
