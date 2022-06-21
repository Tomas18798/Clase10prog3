namespace Api.Models;

public class UserModel
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public int? Age { get; set; }
    public DateTime? DateCreated { get; set; }
    public AddressModel Address { get; set; }
}