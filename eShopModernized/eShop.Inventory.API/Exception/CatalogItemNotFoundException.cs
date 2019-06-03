using System;
using System.Runtime.Serialization;

namespace eShop.Inventory.API.Exception
{
    [Serializable]
    public class CatalogItemStockNotFoundException : System.Exception
    {
        public CatalogItemStockNotFoundException()
        {
        }

        public CatalogItemStockNotFoundException(string message) : base(message)
        {
        }

        public CatalogItemStockNotFoundException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected CatalogItemStockNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}