// //using Microsoft.EntityFrameworkCore;
// using winery_backend.Activity;
// using winery_backend.Vineyard;

public class DataContext : DbContext
{

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    //------------USERS----------------------------------------------------------
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

    public DbSet<Activity> Activities { get; set; }
    public DbSet<Parcel> Parcels { get; set; }
    public DbSet<Supply> Supplies { get; set; }


    //-----------PRODUCTS----------------------------------------------------------
    public DbSet<Product> Products { get; set; }
    public DbSet<Pricing> Pricing { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Discount> Discounts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Activity>().ToTable("Activities");
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
        modelBuilder.Entity<Activity>().ToTable("Activities");
        modelBuilder.Entity<Parcel>().ToTable("Parcels");
        modelBuilder.Entity<Supply>().ToTable("Supplies");
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<Pricing>().ToTable("Pricing");
        modelBuilder.Entity<ProductCategory>().ToTable("ProductCategories");
        modelBuilder.Entity<Discount>().ToTable("Discounts");





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
            }
        );

        modelBuilder.Entity<ProductCategory>().HasData(
            new ProductCategory
            {
                Id = 1,
                Name = "Red"
            },
            new ProductCategory
            {
                Id = 2,
                Name = "White"
            },
            new ProductCategory
            {
                Id = 3,
                Name = "Rose"
            }
        );

        modelBuilder.Entity<Discount>().HasData(
            new Discount
            {
                Id = 1,
                Percentage = 20
            }
        );
        modelBuilder.Entity<Pricing>().HasData(
            new Pricing
            {
                Id = 1,
                Price = 99.99,
                DiscountId = 1
            },
            new Pricing
            {
                Id = 2,
                Price = 235.99
            },
            new Pricing
            {
                Id = 3,
                Price = 132.99
            },
            new Pricing
            {
                Id = 4,
                Price = 72
            }
        );
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Scarlet Elixir Red Wine",
                Description = "Indulge in the rich, velvety depths of Scarlet Elixir Red Wine. Crafted from the finest handpicked grapes, this robust red wine boasts a symphony of flavors, including notes of ripe berries, dark chocolate, and a hint of spice. Perfect for cozy evenings by the fireplace or elegant dinner parties, this wine tantalizes the palate with its smooth texture and lingering finish.",
                Photo = "wine1.png",
                Quantity = 35,
                IsApproved = true,
                PricingId = 1,
                ProductCategoryId = 1
            },
            new Product
            {
                Id = 2,
                Name = "Moonlit Symphony White Wine",
                Description = "Experience the enchanting allure of Moonlit Symphony White Wine. Delicately crafted from sun-kissed grapes, this refreshing white wine captivates with its crisp acidity and vibrant fruit flavors. With hints of citrus, green apple, and tropical notes, each sip evokes a sense of serenity and sophistication. Whether enjoyed on a warm summer evening or paired with your favorite seafood dish, Moonlit Symphony is sure to elevate any occasion.",
                Photo = "wine2.png",
                Quantity = 55,
                IsApproved = true,
                PricingId = 2,
                ProductCategoryId = 2
            },
            new Product
            {
                Id = 3,
                Name = "Blush Blossom Rosé Wine",
                Description = "Transport your senses to a blooming garden with Blush Blossom Rosé Wine. Crafted from select grapes kissed by the gentle rays of the sun, this elegant rosé captivates with its delicate pink hue and enchanting aromas of fresh strawberries and rose petals. With a balanced acidity and subtle sweetness, each sip unfolds like a bouquet of spring flowers. Whether enjoyed with light salads, creamy cheeses, or simply on its own, Blush Blossom is a celebration of life's beautiful moments.",
                Photo = "wine3.png",
                Quantity = 25,
                IsApproved = true,
                PricingId = 3,
                ProductCategoryId = 3
            },
            new Product
            {
                Id = 4,
                Name = "Golden Harvest Chardonnay",
                Description = "Embark on a journey of elegance with Golden Harvest Chardonnay. Grown in sun-drenched vineyards and carefully aged in oak barrels, this exquisite white wine dazzles with its golden hue and rich, buttery texture. With flavors of ripe peach, toasted vanilla, and a hint of caramel, each sip unfolds like a symphony of indulgence. Whether paired with creamy pastas or enjoyed on its own, Golden Harvest is a testament to the artistry of winemaking.",
                Photo = "wine3.png",
                Quantity = 40,
                IsApproved = false,
                PricingId = 4,
                ProductCategoryId = 2
            },
            new Product
            {
                Id = 5,
                Name = "Midnight Noir Cabernet Sauvignon",
                Description = "Discover the allure of Midnight Noir Cabernet Sauvignon. Born from the dark, fertile soils of our vineyards, this bold red wine entices with its deep crimson color and intense aromas of blackberries and plum. With velvety tannins and a lingering finish, each sip evokes a sense of mystery and intrigue. Whether paired with hearty stews or enjoyed on its own, Midnight Noir is a tribute to the enchantment of the night.",
                Photo = "wine3.png",
                Quantity = 30,
                IsApproved = true,
                PricingId = 3,
                ProductCategoryId = 1
            },
            new Product
            {
                Id = 6,
                Name = "Sunrise Serenade Sauvignon Blanc",
                Description = "Awaken your senses with Sunrise Serenade Sauvignon Blanc. Harvested in the early morning light, this crisp white wine exudes freshness and vitality. With vibrant flavors of citrus, melon, and a hint of fresh-cut grass, each sip is a symphony of brightness and clarity. Whether enjoyed with light salads or seafood dishes, Sunrise Serenade is a celebration of new beginnings.",
                Photo = "wine3.png",
                Quantity = 50,
                IsApproved = false,
                PricingId = 4,
                ProductCategoryId = 2
            }

        );

    }
}