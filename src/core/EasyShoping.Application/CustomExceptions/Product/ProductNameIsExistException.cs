namespace EasyShoping.Application.CustomExceptions.Product;

public class ProductNameIsExistException:Exception
{
    public ProductNameIsExistException()
    {
        
    }
    public ProductNameIsExistException(string message) : base(message) { }
}
