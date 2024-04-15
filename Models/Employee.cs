public class Employee : User
{
    public string? ProfilePhoto { get; set; }

    public Employee() { }

    public Employee(RegisterEmployeeDto registerEmployeeDto, string hashedPassword)
    {
        this.Firstname = registerEmployeeDto.Firstname;
        this.Lastname = registerEmployeeDto.Lastname;
        this.Email = registerEmployeeDto.Email;
        this.Username = registerEmployeeDto.Username;
        this.Password = hashedPassword;
        this.Gender = registerEmployeeDto.Gender;
        this.Role = registerEmployeeDto.Role;
        this.PhoneNumber = registerEmployeeDto.PhoneNumber;
        this.BirthDate = registerEmployeeDto.BirthDate;
        this.ProfilePhoto = registerEmployeeDto.ProfilePhoto;
    }
}