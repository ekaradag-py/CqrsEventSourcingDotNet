using DB;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository;

internal class Program
{
    private static void Main(string[] args)
    {
        using var dbContext = new Product1Context();
        using var dbContext2 = new Product2Context();

        var productRepository = new Repository.Repository(dbContext);
        var productRepository2 = new Repository.Repository(dbContext2);

        // Sorgu tarafı işlemleri
        var productQueryHandler = new ProductQueryHandler(productRepository);
        var allProducts = productQueryHandler.GetAllProducts();
        var specificProduct = productQueryHandler.GetProductById(1);

        // Komut tarafı işlemleri
        var productCommandHandler = new ProductCommandHandler(productRepository, productRepository2);
        productCommandHandler.StockRunningLow += ProductCommandHandler_StockRunningLow;

        var newProduct = new ProductModel { ID = 0, ProductName = "New Product", ProductCode = "Code", Amount = 10.99m, Stock = 11 };
        productCommandHandler.AddProduct(newProduct);
        productCommandHandler.UpdateStock(2, -8); // Stok azaltma



        #region test
        //using (var dbContext = new Product2Context())
        //{
        //    var repository = new Repository.Repository(dbContext);
        //    var a = dbContext.TableProduct.ToList();

        //    var entities = new ProductModel
        //    {
        //        ID = 0,
        //        Amount = 15.9m,
        //        ProductName = "Apple Mac",
        //        ProductCode = "AppleM1",
        //        Stock = 10
        //    };
        //    //dbContext.Products.Add(entities);
        //    //dbContext.SaveChanges();
        //    repository.Insert(entities);

        //}
        #endregion

        Console.WriteLine("İşlem tamamlandı.");
        Console.ReadKey();
    }
    private static void ProductCommandHandler_StockRunningLow(object sender, ProductEventArgs e)
    {
        Console.WriteLine($"Uyarı: {e.ProductName} ürününün stok adedi kritik seviyeye düştü. Mevcut stok: {e.Stock}");
    }
    public class ProductCommandHandler
    {
        private readonly IRepository _productCommandRepository;
        private readonly IRepository _productCommandRepository2;
        public event EventHandler<ProductEventArgs> StockRunningLow;

        public ProductCommandHandler(IRepository productCommandRepository, IRepository productCommandRepository2)
        {
            _productCommandRepository = productCommandRepository;
            _productCommandRepository2 = productCommandRepository2;
        }

        public void AddProduct(ProductModel product)
        {
            _productCommandRepository.Insert(product);
            _productCommandRepository2.Insert(product);
        }

        public void UpdateProduct(ProductModel product)
        {
            _productCommandRepository.Update(product);
            _productCommandRepository2.Update(product);
        }

        public void DeleteProduct(int id)
        {
            _productCommandRepository.Delete(id);
            _productCommandRepository2.Delete(id);
        }

        public void UpdateStock(int productId, int quantity)
        {
            var product = _productCommandRepository.GetById(productId);
            product.Stock += quantity;
            if (product.Stock <= 5)
            {
                OnStockRunningLow(new ProductEventArgs { ProductId = product.ID, ProductName = product.ProductName, Stock = product.Stock });
            }
            _productCommandRepository.Update(product);
            _productCommandRepository2.Update(product);
        }

        protected virtual void OnStockRunningLow(ProductEventArgs e)
        {
            StockRunningLow?.Invoke(this, e);
        }
    }

    public class ProductQueryHandler
    {
        private readonly IRepository _productQueryRepository;
        public ProductQueryHandler(IRepository productQueryRepository)
        {
            _productQueryRepository = productQueryRepository;
        }

        public List<ProductModel> GetAllProducts()
        {
            return _productQueryRepository.GetAll();
        }

        public ProductModel GetProductById(int id)
        {
            return _productQueryRepository.GetById(id);
        }
    }

}