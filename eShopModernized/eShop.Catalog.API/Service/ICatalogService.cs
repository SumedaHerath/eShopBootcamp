using eShop.Catalog.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Catalog.API.Service
{
    public interface ICatalogService
    {
        List<CatalogType> GetCatalogTypes();
        List<CatalogBrand> GetCatalogBrands();
        Task<CatalogItem> GetCatalogItemAsync(string id);
        List<CatalogItem> GetCatalogItems(string brandIdFilter, string typeIdFilter);
        Task CreateCatalogItemAsync(CatalogItem catalogItem);
        Task UpdateCatalogItemAsync(string id, CatalogItem catalogItem);        
    }
}
