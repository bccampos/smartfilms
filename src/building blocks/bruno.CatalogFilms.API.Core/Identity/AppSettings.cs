namespace bruno.CatalogFilms.API.Core.Identity
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpiryHour { get; set; }
        public string Issuer { get; set; }
        public string Valid { get; set; }
    }
}