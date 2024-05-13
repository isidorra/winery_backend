namespace winery_backend.ViewLogisticsEmployees.Dto
{
    public class WarehouseWorkerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public WarehouseWorkerDto()
        { 
            
        }

        public WarehouseWorkerDto(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
