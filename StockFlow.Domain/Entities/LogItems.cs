using System;

namespace StockFlow.Domain.Entities;

public class LogItems
{
    public int id {get;set;}
    public string userId {get;set;} = string.Empty; //Utilizar para saber quem modificou o item
    public int itemId {get;set;} //Utilizar para ver qual foi o item modificado
    public DateTime modificadoEm {get;set;} //Utilizar para saber a data
    public Item? item {get;set;}
    
}
