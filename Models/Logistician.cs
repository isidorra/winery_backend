public class Logistician : Employee {
    public Logistician() {}
    public Logistician (Employee employee) {
            this.Firstname = employee.Firstname;
            this.Lastname = employee.Lastname;
            this.Email = employee.Email;
            this.Username = employee.Username;
            this.Password = employee.Password;
            this.Gender = employee.Gender;
            this.Role = employee.Role;
            this.PhoneNumber = employee.PhoneNumber;
            this.BirthDate = employee.BirthDate;
            this.ProfilePhoto = employee.ProfilePhoto;
        }
}