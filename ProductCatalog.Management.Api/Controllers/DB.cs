using ProductCatalog.Management.Api.Model;

namespace ProductCatalog.Management.Api.Controllers
{
    public static class DB
    {
        static List<ProductCatalogModel> catalogs = new();

        static DB()
        {
       
        }

        public static void Save(ProductCatalogModel model)
        {
             catalogs.Add(model);
        }

        public static ProductCatalogModel Get(Guid id)
        {
            return catalogs.FirstOrDefault(x => x.Id == id);
        }
    }
}