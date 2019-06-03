using System;
using System.Runtime.Serialization;

namespace eShop.Catalog.API.Exception
{
    [Serializable]
    public class CatalogItemNotFoundException : System.Exception
    {
        public CatalogItemNotFoundException()
        {
        }

        public CatalogItemNotFoundException(string message) : base(message)
        {
        }

        public CatalogItemNotFoundException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected CatalogItemNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}