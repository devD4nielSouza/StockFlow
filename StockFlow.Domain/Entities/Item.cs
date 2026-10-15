using System;

namespace StockFlow.Domain.Entities;

public class Item
{
    string nome {get;set;} = string.Empty;
    string descrição {get;set;} = string.Empty;
    int quantidade {get;set;}
    decimal preço {get;set;}
}
