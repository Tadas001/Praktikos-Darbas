namespace WebApi.Requests;

public class UserRequest
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public DateTime BirthDate { get; set; }

    public string Email { get; set; }
}