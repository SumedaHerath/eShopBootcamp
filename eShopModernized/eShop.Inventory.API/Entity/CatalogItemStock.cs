using System;

namespace eShop.Inventory.API.Entity
{
    public partial class CatalogItemStock
    {
        public DateTime Date { get; set; }

        public int CatalogItemId { get; set; }

        public int AvailableStock { get; set; }

        public int StockId { get; set; }

        public int ReorderPoint { get; set; }
    }
}
