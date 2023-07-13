namespace webapi.Models;

public class EProfile
{
    public int Id { get; set; }
    public int Age { get; set; }
    public string Company { get; set; }
    public string Name { get; set; }
    public EPerson? Person { get; set; }
}