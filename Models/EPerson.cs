namespace webapi.Models;

public class EPerson
{
    public int Id { get; set; }
    
    public string Email { get; set; }
    
    public EProfile? Profile { get; set; }

    public int? ProfileId { get; set; }
    
}