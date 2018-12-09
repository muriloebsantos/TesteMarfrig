using System.Collections.Generic;

namespace Marfrig.Domain.Models
{
    public class PagedResult<T> where T : class
    {
        public int CurrentPage { get; set; }
        public int TotalRecords { get; set; }
        public int PageSize { get; set; }
        public int TotalPages
        {
            get
            {
                var restoDivisao = TotalRecords % PageSize;
                var divisao = TotalRecords / PageSize;
                var qtdePaginas = divisao + (restoDivisao > 0 ? 1 : 0);
                return qtdePaginas;
            }
        }
        public IEnumerable<T> Data { get; set; }
    }
}
