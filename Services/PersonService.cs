using webapi.Controllers;
using webapi.DTOs;
using webapi.Mappers;
using webapi.Models;

namespace webapi;

public class PersonService
{
    private readonly PersonRepository _personRepository;
    private readonly PersonMapper _personMapper;

    public PersonService()
    {
        this._personRepository = new PersonRepository();
        this._personMapper = new PersonMapper();
    }
    
    public Pagination<DTOs.DPerson> Get(string? term, PaginationParam paginationParam)
    {
        var persons = _personRepository.Get(term, paginationParam);
        return new Pagination<DTOs.DPerson>()
        {
            Page = paginationParam.Page,
            PerPage = paginationParam.PerPage,
            Items = persons.Items.Select(person => _personMapper.ToDto(person)).ToList()
        };
    }

    public DTOs.DPerson Get(int id)
    {
        var person = _personRepository.Get(id);
        return _personMapper.ToDto(person);
    }

    public DTOs.DPerson Add(DTOs.DPerson p)
    {
        var personEntity = _personMapper.ToEntity(p);
        var updatedEntity =  _personRepository.Add(personEntity);

        return _personMapper.ToDto(updatedEntity);
    }

    public DTOs.DPerson Update(DTOs.DPerson dPerson)
    {
        var updatedPersonEntity = _personRepository.Update(_personMapper.ToEntity(dPerson));
        return _personMapper.ToDto(updatedPersonEntity);
    }

    public void Delete(int id)
    {
        _personRepository.Delete(id);
    }
}