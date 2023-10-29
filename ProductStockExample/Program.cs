// Sorgu tarafı
public class ProductQueryHandler
{
    private readonly IProductQueryRepository _productQueryRepository;

    public ProductQueryHandler(IProductQueryRepository productQueryRepository)
    {
        _productQueryRepository = productQueryRepository;
    }

    public List<Product> GetAllProducts()
    {
        return _productQueryRepository.GetAllProducts();
    }

    public Product GetProductById(int id)
    {
        return _productQueryRepository.GetProductById(id);
    }
}

// Komut tarafı
public class ProductCommandHandler
{
    private readonly IProductCommandRepository _productCommandRepository;
    public event EventHandler<ProductEventArgs> StockRunningLow;

    public ProductCommandHandler(IProductCommandRepository productCommandRepository)
    {
        _productCommandRepository = productCommandRepository;
    }

    public void AddProduct(Product product)
    {
        _productCommandRepository.AddProduct(product);
    }

    public void UpdateProduct(Product product)
    {
        _productCommandRepository.UpdateProduct(product);
    }

    public void DeleteProduct(int id)
    {
        _productCommandRepository.DeleteProduct(id);
    }

    public void UpdateStock(int productId, int quantity)
    {
        var product = _productCommandRepository.GetProductById(productId);
        product.Stock += quantity;
        if (product.Stock <= 5)
        {
            OnStockRunningLow(new ProductEventArgs { ProductId = product.Id, ProductName = product.Name, Stock = product.Stock });
        }
        _productCommandRepository.UpdateProduct(product);
    }

    protected virtual void OnStockRunningLow(ProductEventArgs e)
    {
        StockRunningLow?.Invoke(this, e);
    }
}

// Ürün modeli
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    // Diğer özellikler
}

// Ürün olay argümanları
public class ProductEventArgs : EventArgs
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Stock { get; set; }
}

// Sorgu tarafı için ürün deposu arayüzü
public interface IProductQueryRepository
{
    List<Product> GetAllProducts();
    Product GetProductById(int id);
}

// Komut tarafı için ürün deposu arayüzü
public interface IProductCommandRepository
{
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int id);
    Product GetProductById(int id);
}

// Ürün deposu uygulaması
public class ProductRepository : IProductQueryRepository, IProductCommandRepository
{
    private List<Product> _products;

    public ProductRepository()
    {
        _products = new List<Product>();
    }

    public List<Product> GetAllProducts()
    {
        return _products;
    }

    public Product GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;
        }
    }

    public void DeleteProduct(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _products.Remove(product);
        }
    }
}

// Kullanımı
class Program
{
    static void Main(string[] args)
    {
        // Örnek bir ürün deposu oluşturuyoruz
        var productRepository = new ProductRepository();

        // Sorgu tarafı işlemleri
        var productQueryHandler = new ProductQueryHandler(productRepository);
        var allProducts = productQueryHandler.GetAllProducts();
        var specificProduct = productQueryHandler.GetProductById(1);

        // Komut tarafı işlemleri
        var productCommandHandler = new ProductCommandHandler(productRepository);
        productCommandHandler.StockRunningLow += ProductCommandHandler_StockRunningLow;

        var newProduct = new Product { Id = 1, Name = "New Product", Price = 10.99m, Stock = 11 };
        productCommandHandler.AddProduct(newProduct);
        productCommandHandler.UpdateStock(1, -8); // Stok azaltma

        Console.WriteLine("Bitti");
        Console.ReadKey();
    }

    private static void ProductCommandHandler_StockRunningLow(object sender, ProductEventArgs e)
    {
        Console.WriteLine($"Uyarı: {e.ProductName} ürününün stok adedi kritik seviyeye düştü. Mevcut stok: {e.Stock}");
    }
}
