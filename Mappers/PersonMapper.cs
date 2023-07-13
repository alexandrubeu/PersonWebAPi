using webapi.DTOs;
using webapi.Models;

namespace webapi.Mappers;

public class PersonMapper
{
    private readonly ProfileMapper _profileMapper;

    public PersonMapper()
    {
        this._profileMapper = new ProfileMapper();
    }
    
    public DTOs.DPerson ToDto(EPerson person)
    {
        return new DTOs.DPerson
        {
            Id = person.Id,
            Email = person.Email,
            Profile = person.Profile == null ? null : _profileMapper.ToDto(person.Profile)
        };
    }

    public EPerson ToEntity(DTOs.DPerson dPerson)
    {
        return new EPerson()
        {
            Email = dPerson.Email,
            Id = dPerson.Id,
            ProfileId = dPerson.Profile?.Id,
            Profile = dPerson.Profile != null ? _profileMapper.ToEntity(dPerson.Profile) : null
        };
    }
}