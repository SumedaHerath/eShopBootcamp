using eShop.Catalog.API.Models;
using eShop.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Catalog.API.Service
{
    public class CatalogService : ICatalogService
    {
        private readonly IDocumentStore<CatalogType> _catalogTypeStore;
        private readonly IDocumentStore<CatalogBrand> _catalogBrandStore;
        private readonly IDocumentStore<CatalogItem> _catalogItemStore;

        public CatalogService(
            IDocumentStore<CatalogType> catalogTypeStore,
            IDocumentStore<CatalogBrand> catalogBrandStore,
            IDocumentStore<CatalogItem> catalogItemStore
            )
        {
            _catalogTypeStore = catalogTypeStore;
            _catalogTypeStore.Collection = "catalogtypes";
            _catalogBrandStore = catalogBrandStore;
            _catalogTypeStore.Collection = "catalogbrands";
            _catalogItemStore = catalogItemStore;
            _catalogTypeStore.Collection = "catalogitems";
        }

        public List<CatalogType> GetCatalogTypes()
        {
            return _catalogTypeStore.GetItems(x=>x.Deleted == false);
        }

        public List<CatalogBrand> GetCatalogBrands()
        {
            return _catalogBrandStore.GetItems(x => x.Deleted == false);
        }

        public async Task<CatalogItem> GetCatalogItemAsync(string id)
        {
            return await _catalogItemStore.GetItemByIdAsync(id);
        }

        public  List<CatalogItem> GetCatalogItems(string brandIdFilter, string typeIdFilter)
        {
            //   return _catalogItemStore.GetItems(x => (x.CatalogBrandId == brandIdFilter) 
            //   && (x.CatalogTypeId == typeIdFilter));

            return null;
        }

        public async Task CreateCatalogItemAsync(CatalogItem catalogItem)
        {
            await _catalogItemStore.CreateItemAsync(catalogItem);
        }

        public async Task UpdateCatalogItemAsync(string id, CatalogItem catalogItem)
        {
            await _catalogItemStore.UpdateItemAsync(id, catalogItem);
        }
    }
}
