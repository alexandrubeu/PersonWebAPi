using Microsoft.EntityFrameworkCore;
using webapi.DTOs;
using webapi.Models;

namespace webapi.Mappers;

public class CreatePagination<T> where T : class
{
    public Pagination<T> Transform(PaginationParam paginationParam, IQueryable<T> list, DbSet<T> dbSet)
    {
        return new Pagination<T>
        {
            PerPage = paginationParam.PerPage,
            Page = paginationParam.Page,
            TotalCount = dbSet.Count(),
            Items = list.ToList()
        };
    }
}