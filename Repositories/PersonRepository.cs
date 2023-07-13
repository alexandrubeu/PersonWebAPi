using Microsoft.EntityFrameworkCore;
using webapi.DTOs;
using webapi.Mappers;
using webapi.Models;
using webapi.Persistence;

namespace webapi.Controllers;

public class PersonRepository
{
    private readonly CreatePagination<EPerson> _createPagination;

    public PersonRepository()
    {
        _createPagination = new CreatePagination<EPerson>();
    }
    
    public Pagination<EPerson> Get(string? term, PaginationParam paginationParam)
    {
        using var context = new Context();
        var persons = context.Persons
            .Include(p => p.Profile)
            .Skip(paginationParam.PerPage * paginationParam.Page)
            .Take(paginationParam.PerPage);


        if (!string.IsNullOrWhiteSpace(term))
        {
            persons = persons.Where(p => p.Email.Contains(term));
        }

        return this._createPagination.Transform(paginationParam, persons, context.Persons);
        
        // return new Pagination<EPerson>()
        // {
        //     Page = paginationParam.Page,
        //     PerPage = paginationParam.PerPage,
        //     TotalCount = context.Persons.Count(),
        //     Items = persons.ToList()
        // };
    }

    public EPerson Get(int personId)
    {
        using var context = new Context();
        return context.Persons
            .Include(p => p.Profile)
            .Single(z => z.Id == personId);
    }

    public EPerson Update(EPerson person)
    {
        using var context = new Context();
        context.Update(person);
        context.SaveChanges();

        return this.Get(person.Id);
    }

    public EPerson Add(EPerson person)
    {
        using var context = new Context();
        context.Add(person);
        context.SaveChanges();

        return this.Get(person.Id);
    }

    public void Delete(int id)
    {
        var person = this.Get(id);
        using var context = new Context();
        context.RemoveRange(person, person.Profile);

        context.SaveChanges();
    }
}