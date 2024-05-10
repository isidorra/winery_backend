using winery_backend.ViewWarehouse.Models;

public class Warehouseman : Employee {
    
    public int SectorId { get; set; }
    public Warehouseman() {}
    public Warehouseman (Employee employee) {
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

    public Warehouseman(Employee employee, int sectorId)
    {
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
        SectorId = sectorId;
    }
}