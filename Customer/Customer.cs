public class Customer : User
{
    public string? Street { get; set; }
    public string? Number { get; set; }
    public string? Floor { get; set; }
    public string? Door { get; set; }
    public int? CityId { get; set; }
    
    // Navigation property
    public City City { get; set; }

    public Customer() { }

    public Customer(string firstname, string lastname, string email, string username, string password, Gender gender, Role role, string phoneNumber, DateTime birthDate, string? street, string? number, string? floor, string? door, int? cityId)
    {
        Street = street;
        Number = number;
        Floor = floor;
        Door = door;
        CityId = cityId;
    }
    

    public Customer(RegisterCustomerDto registerCustomerDto, string hashedPassword)
    {
        this.Firstname = registerCustomerDto.Firstname;
        this.Lastname = registerCustomerDto.Lastname;
        this.Email = registerCustomerDto.Email;
        this.Username = registerCustomerDto.Username;
        this.Password = hashedPassword;
        this.Gender = registerCustomerDto.Gender;
        this.Role = global::Role.CUSTOMER;
        this.PhoneNumber = registerCustomerDto.PhoneNumber;
        this.BirthDate = registerCustomerDto.BirthDate;
    }
    
}