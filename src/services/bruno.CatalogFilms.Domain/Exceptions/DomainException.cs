namespace bruno.CatalogFilms.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        { }
    }
}
