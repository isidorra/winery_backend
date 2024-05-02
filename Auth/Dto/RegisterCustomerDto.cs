public class RegisterCustomerDto {
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Email { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? PhoneNumber { get; set; }
    public int CityId = 0;
    public DateTime? BirthDate { get; set; }
    public Gender? Gender { get; set; }
}