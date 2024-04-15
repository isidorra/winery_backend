using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<AppUser> {
    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) {

    }

    protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMININISTRATOR"
                },
                new IdentityRole
                {
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                },
                new IdentityRole 
                {
                    Name = "Owner",
                    NormalizedName = "OWNER"
                },
                new IdentityRole 
                {
                    Name = "SalesManager",
                    NormalizedName = "SALES_MANAGER"
                },
                new IdentityRole
                {
                    Name = "MarketingManager",
                    NormalizedName = "MARKETING_MANAGER"
                },
                new IdentityRole
                {
                    Name = "Technologist",
                    NormalizedName = "TECHNOLOGIST"
                },
                new IdentityRole 
                {
                    Name = "Logistician",
                    NormalizedName = "LOGISTICIAN"
                },
                new IdentityRole
                {
                    Name = "Warehouseman",
                    NormalizedName = "WAREHOUSEMAN"
                },
                new IdentityRole
                {
                    Name = "Driver",
                    NormalizedName = "DRIVER"
                },
                new IdentityRole
                {
                    Name = "TourGuide",
                    NormalizedName = "TOUR_GUIDE"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }


}