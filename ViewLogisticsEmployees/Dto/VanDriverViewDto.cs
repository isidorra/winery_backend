using System.Reflection;

namespace winery_backend.ViewLogisticsEmployees.Dto
{
    public class VanDriverViewDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public string ProfilePhoto { get; set; }

        public VanDriverViewDto()
        {

        }

        public VanDriverViewDto(string firstname, string lastname, string email, string username, string password, string phoneNumber, DateTime? birthDate, Gender? gender, string profilePhoto)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Username = username;
            Password = password;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            if (gender == 0)
            {
                Gender = "female";
            }
            else
            {
                Gender = "male";
            }
            ProfilePhoto = profilePhoto;
        }

        public VanDriverViewDto(Employee employee)
        {
            Firstname = employee.Firstname;
            Lastname = employee.Lastname;
            Email = employee.Email;
            Username = employee.Username;
            Password = employee.Password;
            PhoneNumber = employee.PhoneNumber;
            BirthDate = employee.BirthDate;
            if (employee.Gender == 0)
            {
                Gender = "female";
            }
            else
            {
                Gender = "male";
            }
            ProfilePhoto = employee.ProfilePhoto;
        }
    }
}
