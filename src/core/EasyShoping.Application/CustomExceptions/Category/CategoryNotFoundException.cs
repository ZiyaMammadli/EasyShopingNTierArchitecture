﻿namespace EasyShoping.Application.CustomExceptions.Category;

public class CategoryNotFoundException:Exception
{
    public CategoryNotFoundException()
    {
        
    }
    public CategoryNotFoundException(string message):base(message) { }
}
