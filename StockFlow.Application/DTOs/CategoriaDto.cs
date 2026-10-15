using System;

namespace StockFlow.Application.DTOs;

public class CategoriaDto
{
    public int id {get;set;}
    public string nome {get;set;} = string.Empty;
}

public class CriarCategoriaDto
{
    public string nome {get;set;} = string.Empty;

}

public class AtualizarCategoriaDto
{
       public string nome {get;set;} = string.Empty;

}