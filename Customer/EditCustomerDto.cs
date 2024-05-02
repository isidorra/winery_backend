    public class EditCustomerDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? Floor { get; set; }
        public string? Door { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? PhoneNumber { get; set; }

        public EditCustomerDto(string firstName, string lastName, string email, string username, string password, string street, string number, string floor, string door, string city, string zipCode, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Username = username;
            Password = password;
            Street = street;
            Number = number;
            Floor = floor;
            Door = door;
            City = city;
            ZipCode = zipCode;
            PhoneNumber = phoneNumber;
        }
    }

