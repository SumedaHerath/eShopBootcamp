using eShop.Core.SeedWork;

namespace eShop.Catalog.API.Models
{
    public class CatalogItem : Entity
    {
        public string Description { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public CatalogType CatalogType { get; set; }

        public CatalogBrand CatalogBrand { get; set; }
    }
}
