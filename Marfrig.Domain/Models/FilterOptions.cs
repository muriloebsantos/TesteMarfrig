namespace Marfrig.Domain.Models
{
    public class FilterOptions
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int Skip => (CurrentPage * PageSize) - PageSize;
    }
}
