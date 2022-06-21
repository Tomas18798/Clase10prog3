namespace Api.Models;

public class UserCreateModel
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public int? Age { get; set; }
    public AddressModel Address { get; set; }
}