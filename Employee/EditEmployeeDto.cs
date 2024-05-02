
    public class EditEmployeeDto
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? ProfilePhoto { get; set; }

        public EditEmployeeDto(string? firstname, string? lastname, string? email, string? username, string? password, string? profilePhoto)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Username = username;
            Password = password;
            ProfilePhoto = profilePhoto;
        }
    }

