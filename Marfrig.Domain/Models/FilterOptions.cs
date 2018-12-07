namespace Marfrig.Domain.Models
{
    public class FilterOptions
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int Skip
        {
            get
            {
                return (CurrentPage * PageSize) - PageSize;
            }
        }
    }
}
