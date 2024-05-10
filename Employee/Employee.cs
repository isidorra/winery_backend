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

    public Employee(int id, string firstName, string lastName, string email, string username, string password, string phoneNumber, DateTime birthDate, Gender gender, Role role, string profilePhoto)
    {
        this.Id = id;
        this.Firstname=firstName;
        this.Lastname=lastName;
        this.Email=email;
        this.Username=username;
        this.Password=password;
        this.PhoneNumber = phoneNumber;
        this.BirthDate = birthDate;
        this.Gender = gender;
        this.Role = role;
        this.ProfilePhoto = profilePhoto;
    }
}