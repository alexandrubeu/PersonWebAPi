using webapi.DTOs;
using webapi.Models;

namespace webapi.Mappers;

public class ProfileMapper
{
    public DTOs.DProfile ToDto(EProfile profile)
    {
        return new DProfile()
        {
            Id = profile.Id,
            Age = profile.Age,
            Name = profile.Name,
            Company = profile.Company
        };
    }

    public EProfile ToEntity(DTOs.DProfile dProfile)
    {
        return new EProfile()
        {
            Id = dProfile.Id,
            Age = dProfile.Age,
            Company = dProfile.Company,
            Name = dProfile.Name,
        };
    }
}