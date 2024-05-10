using Microsoft.EntityFrameworkCore;
using winery_backend.LogisticianViewCustomerOrder.Models;
using winery_backend.PackingRequest.Models;
using winery_backend.ViewWarehouse.Models;

public class DataContext : DbContext
{

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Logistician> Logisticians { get; set; }
    public DbSet<MarketingManager> MarketingManagers { get; set; }
    public DbSet<SalesManager> SalesManagers { get; set; }
    public DbSet<Technologist> Technologists { get; set; }
    public DbSet<TourGuide> TourGuides { get; set; }
    public DbSet<VanDriver> VanDrivers { get; set; }
    public DbSet<Warehouseman> Warehousemen { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<CustomerOrder> CustomerOrders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<RealTimeOrderTrackingStatus> RealTimeOrderTrackingStatuses { get; set; }
    public DbSet<PackingRequest> PackingRequests { get; set; }
    public DbSet<Sector> Sectors { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<City>().ToTable("Cities");
        modelBuilder.Entity<Customer>().ToTable("Customers");
        modelBuilder.Entity<Employee>().ToTable("Employees");
        modelBuilder.Entity<Owner>().ToTable("Owners");
        modelBuilder.Entity<Administrator>().ToTable("Administrators");
        modelBuilder.Entity<Logistician>().ToTable("Logisticians");
        modelBuilder.Entity<MarketingManager>().ToTable("MarketingManagers");
        modelBuilder.Entity<SalesManager>().ToTable("SalesManagers");
        modelBuilder.Entity<Technologist>().ToTable("Technologists");
        modelBuilder.Entity<TourGuide>().ToTable("TourGuides");
        modelBuilder.Entity<VanDriver>().ToTable("VanDrivers");
        modelBuilder.Entity<Warehouseman>().ToTable("Warehousemen");
        modelBuilder.Entity<CustomerOrder>().ToTable("CustomerOrders");
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<RealTimeOrderTrackingStatus>().ToTable("RealTimeOrderTrackingStatuses");
        modelBuilder.Entity<PackingRequest>().ToTable("PackingRequests");
        modelBuilder.Entity<Sector>().ToTable("Sectors");
        modelBuilder.Entity<Warehouse>().ToTable("Warehouses");

        //

        modelBuilder.Entity<Product>().HasData(
            new Product(1, "a", "aa", "aaa", "sorta_1", new Decimal(1.5), 1000, new Decimal(5), 1),
            new Product(2, "b", "bb", "bbb", "sorta_2", new Decimal(0.5), 2000, new Decimal(6), 2)
        );

        List<int> products1 = new List<int>();
        products1.Add(1);
        products1.Add(2);

        List<int> quantities1 = new List<int>();
        quantities1.Add(3);
        quantities1.Add(2);

        List<int> products2 = new List<int>();
        products2.Add(2);

        List<int> quantities2 = new List<int>();
        quantities2.Add(6);

        modelBuilder.Entity<CustomerOrder>().HasData(
            new CustomerOrder(1, new Decimal(20.3), new DateTime(2020, 3, 20), new DateTime(2020, 3, 30), 1, products1, quantities1, 1),
            new CustomerOrder(2, new Decimal(10.5), new DateTime(2021, 5, 22), new DateTime(2021, 6, 1), 2, products2, quantities2, 1)
        );

        modelBuilder.Entity<RealTimeOrderTrackingStatus>().HasData(
            new RealTimeOrderTrackingStatus(1, "in processing"),
            new RealTimeOrderTrackingStatus(2, "distributed")
        );

        modelBuilder.Entity<Sector>().HasData(
            new Sector(1, "SECTOR 1", "slika1", 1, 1),
            new Sector(2, "SECTOR 2", "slika2", 1, 2)
        );

        modelBuilder.Entity<Warehouse>().HasData(
            new Warehouse(1, "Warehouse 1", new Decimal(450.23), 2, 1, 2, "slika 1")
        );

        /*modelBuilder.Entity<Employee>().HasData(
            new Employee(10, "A", "A", "a@gmail.com", "aaaaa", "aaaaa", "1234567890", new DateTime(1990, 5, 20), Gender.MALE, Role.WAREHOUSEMAN, "slika1"),
            new Employee(11, "B", "B", "b@gmail.com", "bbbbb", "bbbbb", "1234567890", new DateTime(1991, 6, 21), Gender.MALE, Role.WAREHOUSEMAN, "slika2")
        );*/

        /*modelBuilder.Entity<PackingRequest>().HasData(
            new PackingRequest(10, "A", "A", "a@gmail.com", "aaaaa", "aaaaa", "1234567890", new DateTime(1990, 5, 20), Gender.MALE, Role.WAREHOUSEMAN, "slika1"),
            new Employee(11, "B", "B", "b@gmail.com", "bbbbb", "bbbbb", "1234567890", new DateTime(1991, 6, 21), Gender.MALE, Role.WAREHOUSEMAN, "slika2")
        );

                public int PackingRequestId { get; set; }
    public DateTime PackingRequestDeadlineDate { get; set; }
    public DateTime PackingRequestCreationDate { get; set; }
    public List<int> PackingRequestProductIds { get; set; }
    public List<int> PackingRequestQuantities { get; set; }
    public int CustomerOrderId { get; set; }
    public int SectorId { get; set; }*/

        //



        modelBuilder.Entity<City>().HasData(
            new City { Id = 1, Name = "Belgrade", Zip = "11000" },
            new City { Id = 2, Name = "Novi Sad", Zip = "21000" },
            new City { Id = 3, Name = "Niš", Zip = "18000" },
            new City { Id = 4, Name = "Kragujevac", Zip = "34000" },
            new City { Id = 5, Name = "Subotica", Zip = "24000" },
            new City { Id = 6, Name = "Zrenjanin", Zip = "23000" },
            new City { Id = 7, Name = "Pančevo", Zip = "26000" },
            new City { Id = 8, Name = "Čačak", Zip = "32000" },
            new City { Id = 9, Name = "Kraljevo", Zip = "36000" },
            new City { Id = 10, Name = "Smederevo", Zip = "11300" },
            new City { Id = 11, Name = "Leskovac", Zip = "16000" },
            new City { Id = 12, Name = "Valjevo", Zip = "14000" },
            new City { Id = 13, Name = "Užice", Zip = "31000" },
            new City { Id = 14, Name = "Šabac", Zip = "15000" },
            new City { Id = 15, Name = "Novi Pazar", Zip = "36300" },
            new City { Id = 16, Name = "Negotin", Zip = "19300" }
        );
        

        modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                Id = 1,
                Firstname = "John",
                Lastname = "Doe",
                Email = "john.doe@example.com",
                Username = "johndoe",
                Password = "hashedpassword", // Replace with hashed password
                PhoneNumber = "1234567890",
                BirthDate = new DateTime(1990, 5, 15),
                Gender = Gender.MALE,
                Role = Role.CUSTOMER,
                Street = "123 Main St",
                Number = "101",
                Floor = null,
                Door = null,
                CityId = 1, // Reference to New York
            },
            new Customer
            {
                Id = 2,
                Firstname = "Jane",
                Lastname = "Doe",
                Email = "jane.doe@example.com",
                Username = "janedoe",
                Password = "hashedpassword",
                PhoneNumber = "9876543210",
                BirthDate = new DateTime(1992, 8, 20),
                Gender = Gender.FEMALE,
                Role = Role.CUSTOMER,
                Street = "456 Elm St",
                Number = "202",
                Floor = "2",
                Door = "3",
                CityId = 2,
            }
        );
        
        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                Firstname = "Pera",
                Lastname = "Peric",
                Email = "pera.peric@example.com",
                Username = "peraperic",
                Password = "hashedpassword",
                PhoneNumber = "1234567890",
                BirthDate = new DateTime(1990, 5, 15),
                Gender = Gender.MALE,
                Role = Role.DRIVER,
                ProfilePhoto = "somepath"
            },
            new Employee
            {
                Id = 2,
                Firstname = "Imenko",
                Lastname = "Prezimenic",
                Email = "imenko@example.com",
                Username = "imenko",
                Password = "hashedpassword",
                PhoneNumber = "9876543210",
                BirthDate = new DateTime(1992, 8, 20),
                Gender = Gender.MALE,
                Role = Role.ADMINISTRATOR,
                ProfilePhoto = "somepath"
            },
            new Employee
            {
                Id = 3,
                Firstname = "Admin",
                Lastname = "Adminovic",
                Email = "admin@admin.com",
                Username = "admin123",
                Password = "$2a$10$dVNZNTm8Ts9fGjM3M8QuE.LF0ZutYn1utYoeSdfZZXbB0ec9MjBUS",
                PhoneNumber = "061111111",
                BirthDate = new DateTime(1982, 8, 20),
                Gender = Gender.MALE,
                Role = Role.ADMINISTRATOR,
                ProfilePhoto = "somepath"
            },
            new Employee(11, "A", "A", "a@gmail.com", "aaaaa", "aaaaa", "1234567890", new DateTime(1990, 5, 20), Gender.MALE, Role.WAREHOUSEMAN, "slika1"),
            new Employee(12, "B", "B", "b@gmail.com", "bbbbb", "bbbbb", "1234567890", new DateTime(1991, 6, 21), Gender.MALE, Role.WAREHOUSEMAN, "slika2")
        );
        
        // modelBuilder.Entity<Owner>().HasData(
        //     new Owner(new Employee // Instantiate Employee object
        //     {
        //         Id = -1,
        //         Firstname = "Perko",
        //         Lastname = "Peric",
        //         Email = "perko.peric@example.com",
        //         Username = "perkoperic",
        //         Password = "hashedpassword",
        //         PhoneNumber = "543123967",
        //         BirthDate = new DateTime(1990, 5, 15),
        //         Gender = Gender.MALE,
        //         Role = Role.OWNER,
        //         ProfilePhoto = "somepath"
        //     })
        // );

        // 
    }
}