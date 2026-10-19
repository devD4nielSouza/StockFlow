using System;
using StockFlow.Application.DTOs;

namespace StockFlow.Application.ViewModels;

public class ViewModels
{
    public class ItemViewModel
    {
        public IEnumerable<ItemDto> items {get;set;} = new List<ItemDto> ();
        public int tamanhoPagina {get;set;}
        public int totalItems {get;set;}
        public int totalCategorias {get;set;}
        public int estoqueGeral {get;set;}
        public IEnumerable<CategoriaDto> categorias {get;set;} = new List<CategoriaDto>();
    }

    public class DashboardViewModel
    {
         public int totalItems {get;set;}
        public int totalCategorias {get;set;}
        public int estoqueGeral {get;set;}
    }

    
}
