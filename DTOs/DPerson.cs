namespace webapi.DTOs;

public class DPerson
{
    public int Id { get; set; }
    public string Email { get; set; }
    public DProfile? Profile { get; set; }
}