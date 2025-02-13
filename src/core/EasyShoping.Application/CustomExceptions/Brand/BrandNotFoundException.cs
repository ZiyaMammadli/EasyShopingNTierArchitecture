namespace EasyShoping.Application.CustomExceptions.Brand;

public class BrandNotFoundException:Exception
{
    public BrandNotFoundException()
    {
        
    }
    public BrandNotFoundException(string message) : base(message) { }
}
