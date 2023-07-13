using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Models;
using webapi.Persistence;

namespace webapi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PersonsController : Controller
{
    private readonly PersonService _personService;

    public PersonsController()
    {
        _personService = new PersonService();
    }

    // http://localhost:3221/api/v1/persons?term=something
    [HttpGet("{id}")]
    public ActionResult<EPerson> Get(int id)
    {
        try
        {
            return this.Ok(_personService.Get(id));
        }
        catch (InvalidOperationException e)
        {
            return NotFound("The selected person can not be found");
        }
    }

    // http://localhost:3221/api/v1/persons/id
    [HttpGet]
    public ActionResult<Pagination<DTOs.DPerson>> Get([FromQuery] string? term,
        [FromQuery] PaginationParam paginationParam)
    {
        return this.Ok(_personService.Get(term, paginationParam));
    }

    [HttpPost]
    public ActionResult<DPerson> Add([FromBody] DPerson dPerson)
    {
        return this.Ok(_personService.Add(dPerson));
    }

    [HttpPut("{id}")]
    public ActionResult<DTOs.DPerson> Update(int id, DTOs.DPerson dPerson)
    {
        dPerson.Id = id;
        return this.Ok(_personService.Update(dPerson));
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _personService.Delete(id);
        return this.Ok();
    }
}