public class Customer : User
{
    public string? Street { get; set; }
    public string? Number { get; set; }
    public int? Floor { get; set; }
    public int? Door { get; set; }
    public int CityId { get; set; }
    public String? Zip {get;set;}

    public Customer() { }

    public Customer(string? street, string? number, int? floor, int? door, int cityId, string? zip)
    {
        Street = street;
        Number = number;
        Floor = floor;
        Door = door;
        CityId = cityId;
        Zip = zip;
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