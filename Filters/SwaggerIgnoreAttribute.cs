using System;

namespace BackEnd.Filters
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SwaggerIgnoreAttribute : Attribute
    {
    }
}
