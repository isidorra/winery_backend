
public class RegisterEmployeeDto
{
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Email { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? PhoneNumber { get; set; }

    public Role? Role { get; set; }
    public DateTime? BirthDate { get; set; }
    public Gender? Gender { get; set; }

    public string? ProfilePhoto { get; set; }
}
