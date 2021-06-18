using AutoMapper;
using System.Collections.Generic;
namespace BackEnd.Models
{
    public class Page<T>
    {
        public IEnumerable<T> Records { get; set; }
        public long RecordsTotal { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public Page<TResult> MapearModel<TResult>(IMapper mapper)
        {
            return new Page<TResult>
            {
                Records = mapper.Map<IEnumerable<TResult>>(this.Records),
                RecordsTotal = this.RecordsTotal,
                PageNumber = this.PageNumber,
                PageSize = this.PageSize,
                TotalPages = this.TotalPages
            };
        }
    }
}
