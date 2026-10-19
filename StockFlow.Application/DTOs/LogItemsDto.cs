using System;

namespace StockFlow.Application.DTOs;

public class LogItemsDto
{
    public int id {get;set;}
    public string userId {get;set;} = string.Empty; //Utilizar para saber quem modificou o item
    public int itemId {get;set;} //Utilizar para ver qual foi o item modificado
    public DateTime modificadoEm {get;set;} //Utilizar para saber a data
}

public class CriarLogItemDto
{
    public int itemId { get; set; } //Utilizar para ver qual foi o item modificado
    public string userId {get;set;} = string.Empty; //Utilizar para saber quem modificou o item

}
