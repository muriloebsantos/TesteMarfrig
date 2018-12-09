using System.Collections.Generic;

namespace Marfrig.Application.DTOs
{
    public class PagedResultDTO<T> where T : class
    {
        public int CurrentPage { get; set; }
        public int TotalRecords { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
