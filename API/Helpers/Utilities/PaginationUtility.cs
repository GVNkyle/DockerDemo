using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Helpers.Utilities
{
    public class PaginationUtility<T> where T : class
    {
        public PaginationResult Pagination { get; set; }
        public List<T> Result { get; set; }

        public PaginationUtility(List<T> items, int count, int pageNumber, int pageSize, int skip)
        {
            Result = items;
            Pagination = PaginationResult.Create(count, pageNumber, pageSize, skip);
        }

        public static async Task<PaginationUtility<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize = 10, bool isPaging = true)
        {
            var count = await source.CountAsync();
            var skip = (pageNumber - 1) * pageSize;
            var items = isPaging ? await source.Skip(skip).Take(pageSize).ToListAsync() : await source.ToListAsync();

            return new PaginationUtility<T>(items, count, pageNumber, pageSize, skip);
        }

        public static PaginationUtility<T> Create(List<T> source, int pageNumber, int pageSize = 10, bool isPaging = true)
        {
            var count = source.Count();
            var skip = (pageNumber - 1) * pageSize;
            var items = isPaging ? source.Skip(skip).Take(pageSize).ToList() : source.ToList();

            return new PaginationUtility<T>(items, count, pageNumber, pageSize, skip);
        }

        public class PaginationResult
        {
            public int TotalCount { get; set; }
            public int TotalPage { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public int Skip { get; set; }

            public PaginationResult(int count, int pageNumber, int pageSize, int skip)
            {
                TotalCount = count;
                TotalPage = (int)Math.Ceiling(TotalCount / (double)pageSize);
                PageNumber = pageNumber;
                PageSize = pageSize;
                Skip = skip;
            }

            public static PaginationResult Create(int count, int pageNumber, int pageSize, int skip)
            {
                return new PaginationResult(count, pageNumber, pageSize, skip);
            }
        }
    }

    public class PaginationParam
    {
        private const int MaxPageSize = 10;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
    }
}