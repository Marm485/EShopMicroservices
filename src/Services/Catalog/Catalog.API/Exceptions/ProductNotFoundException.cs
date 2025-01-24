namespace Catalog.API.Exceptions;

public class ProductNotFoundException : Exception
{
    public ProductNotFoundException() : base("Product not found!")
    {
        
    }

    public ProductNotFoundException(string message)
        : base(message)
    {
        
    }

    public ProductNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
        
    }
}
