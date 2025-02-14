namespace EasyShoping.Application.CustomExceptions.Product;

public class ProductNotFoundException:Exception
{
    public ProductNotFoundException()
    {
        
    }
    public ProductNotFoundException(string message):base(message) { }
}
