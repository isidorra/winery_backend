
    public class EditEmployeeDto
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }

        public EditEmployeeDto(string? firstname, string? lastname, string? email, string? password, string? phoneNumber)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
        }
    }

