using Marfrig.Domain.Entities;
using System.Collections.Generic;

namespace Marfrig.Domain.Models
{
    public class PagingResult<T> where T : DomainEntity
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
                var qtdePaginas = divisao + restoDivisao;
                return qtdePaginas;
            }
        }
        public IEnumerable<T> Data { get; set; }
    }
}
