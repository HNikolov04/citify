namespace Citify.Domain.Exceptions;

public class DuplicateNameException : Exception
{
    public DuplicateNameException(string name, string entity)
        : base($"{entity} with name '{name}' already exists.")
    {
    }
}
