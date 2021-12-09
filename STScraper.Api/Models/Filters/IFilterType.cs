namespace STScraper.Api.Models.Filters
{
    public interface IFilterType<in T>
    {
        bool IsFiltered(T obj);
    }
}