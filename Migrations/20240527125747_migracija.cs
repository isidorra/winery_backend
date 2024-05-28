using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace winery_backend.Migrations
{
    /// <inheritdoc />
    public partial class migracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Zip = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CustomerOrders",
                columns: table => new
                {
                    CustomerOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerOrderPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CustomerOrderCreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CustomerOrderDeliveryDeadline = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    OrderTrackingStatusId = table.Column<int>(type: "int", nullable: false),
                    ProductIds = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantities = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrders", x => x.CustomerOrderId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Percentage = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProfilePhoto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Firstname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lastname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Username = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MachineOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SupplierMachineIds = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    MachineOrderCreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DaysUntilDelivery = table.Column<int>(type: "int", nullable: false),
                    Completed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineOrders", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    MachineState = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Manufacturer = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Free = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PackingRequests",
                columns: table => new
                {
                    PackingRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PackingRequestDeadlineDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PackingRequestCreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PackingRequestProductIds = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PackingRequestQuantities = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerOrderId = table.Column<int>(type: "int", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    Packed = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackingRequests", x => x.PackingRequestId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RealTimeOrderTrackingStatuses",
                columns: table => new
                {
                    RealTimeOrderTrackingStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderTrackingStatus = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealTimeOrderTrackingStatuses", x => x.RealTimeOrderTrackingStatusId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    SectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SectorName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SectorImage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    WarehousemanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.SectorId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SupplierProducts",
                columns: table => new
                {
                    SupplierProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SupplierProductName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SupplierProductPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    SupplierProductManufacturer = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SupplierProductAmount = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierProducts", x => x.SupplierProductId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SupplierName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SupplierAddress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SupplierProductIds = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Supplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SupplyType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    Manufacturer = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SupplyOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SupplierSupplyIds = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    SupplyOrderCreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DaysUntilDelivery = table.Column<int>(type: "int", nullable: false),
                    Completed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyOrders", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TransportRequests",
                columns: table => new
                {
                    TransportRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PickUpDeadlineDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TransportRequestCreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TransportRequestDeliveryDeadlineDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SectorIdsForPickUp = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerUsername = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerDeliveryAddress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerOrderId = table.Column<int>(type: "int", nullable: false),
                    VanDriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportRequests", x => x.TransportRequestId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WarehouseName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WarehouseArea = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    WarehouseLocation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumberOfWarehouseWorkers = table.Column<int>(type: "int", nullable: false),
                    NumberOfVanDrivers = table.Column<int>(type: "int", nullable: false),
                    NumberOfSectors = table.Column<int>(type: "int", nullable: false),
                    WarehouseImage = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Number = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Floor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Door = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    Firstname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lastname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Username = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pricing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<double>(type: "double", nullable: true),
                    DiscountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pricing_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrators_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Logisticians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logisticians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logisticians_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MarketingManagers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketingManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketingManagers_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Owners_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SalesManagers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesManagers_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Technologists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Technologists_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TourGuides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourGuides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourGuides_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VanDrivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SomethingForTest = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VanDrivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VanDrivers_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Warehousemen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehousemen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehousemen_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Grapes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsRipe = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Quality = table.Column<int>(type: "int", nullable: false),
                    PlantingDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FertilizerId = table.Column<int>(type: "int", nullable: true),
                    PesticideId = table.Column<int>(type: "int", nullable: true),
                    HarvestedAmount = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grapes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grapes_Supplies_FertilizerId",
                        column: x => x.FertilizerId,
                        principalTable: "Supplies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Grapes_Supplies_PesticideId",
                        column: x => x.PesticideId,
                        principalTable: "Supplies",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Photo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    IsApproved = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    PricingId = table.Column<int>(type: "int", nullable: true),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: true),
                    PackagingSize = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    AlcoholPercentage = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Pricing_PricingId",
                        column: x => x.PricingId,
                        principalTable: "Pricing",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Fermentations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    GrapeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "double", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Yeast = table.Column<double>(type: "double", nullable: false),
                    Sugar = table.Column<double>(type: "double", nullable: false),
                    Temperature = table.Column<double>(type: "double", nullable: false),
                    PhValue = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fermentations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fermentations_Grapes_GrapeId",
                        column: x => x.GrapeId,
                        principalTable: "Grapes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Parcels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GrapeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "double", nullable: false),
                    Size = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcels_Grapes_GrapeId",
                        column: x => x.GrapeId,
                        principalTable: "Grapes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ActivityType = table.Column<int>(type: "int", nullable: false),
                    ParcelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Parcels_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Fertilizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    FertilizerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fertilizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fertilizations_Activities_Id",
                        column: x => x.Id,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fertilizations_Supplies_FertilizerId",
                        column: x => x.FertilizerId,
                        principalTable: "Supplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Harvestings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Amount = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harvestings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Harvestings_Activities_Id",
                        column: x => x.Id,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PesticideControls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    PesticideId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PesticideControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PesticideControls_Activities_Id",
                        column: x => x.Id,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PesticideControls_Supplies_PesticideId",
                        column: x => x.PesticideId,
                        principalTable: "Supplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Waterings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Amount = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waterings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Waterings_Activities_Id",
                        column: x => x.Id,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "Zip" },
                values: new object[,]
                {
                    { 1, "Belgrade", "11000" },
                    { 2, "Novi Sad", "21000" },
                    { 3, "Niš", "18000" },
                    { 4, "Kragujevac", "34000" },
                    { 5, "Subotica", "24000" },
                    { 6, "Zrenjanin", "23000" },
                    { 7, "Pančevo", "26000" },
                    { 8, "Čačak", "32000" },
                    { 9, "Kraljevo", "36000" },
                    { 10, "Smederevo", "11300" },
                    { 11, "Leskovac", "16000" },
                    { 12, "Valjevo", "14000" },
                    { 13, "Užice", "31000" },
                    { 14, "Šabac", "15000" },
                    { 15, "Novi Pazar", "36300" },
                    { 16, "Negotin", "19300" }
                });

            migrationBuilder.InsertData(
                table: "CustomerOrders",
                columns: new[] { "CustomerOrderId", "CustomerId", "CustomerOrderCreationTime", "CustomerOrderDeliveryDeadline", "CustomerOrderPrice", "OrderTrackingStatusId", "ProductIds", "Quantities" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 7000m, 1, "[1,2]", "[3,2]" },
                    { 2, 1, new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 12000m, 1, "[2]", "[6]" },
                    { 3, 2, new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 13500m, 1, "[2,5]", "[6,1]" },
                    { 4, 2, new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 9000m, 1, "[2,3,5]", "[2,3,4]" },
                    { 5, 2, new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 9000m, 2, "[1,4]", "[4,10]" }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "Percentage" },
                values: new object[] { 1, 20.0 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "Email", "Firstname", "Gender", "Lastname", "Password", "PhoneNumber", "ProfilePhoto", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera.peric@example.com", "Pera", 1, "Peric", "hashedpassword", "1234567890", "somepath", 7, "peraperic" },
                    { 2, new DateTime(1992, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "imenko@example.com", "Imenko", 1, "Prezimenic", "hashedpassword", "9876543210", "somepath", 0, "imenko" },
                    { 3, new DateTime(1982, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", 1, "Adminovic", "$2a$10$dVNZNTm8Ts9fGjM3M8QuE.LF0ZutYn1utYoeSdfZZXbB0ec9MjBUS", "061111111", "somepath", 0, "admin123" },
                    { 11, new DateTime(1990, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "warehouseman_email_1@gmail.com", "warehouseman_first_name_1", 1, "warehouseman_last_name_1", "a", "061123123", "photo_warehouseman_1.png", 4, "warehouseman_1" },
                    { 12, new DateTime(1991, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "warehouseman_email_2@gmail.com", "warehouseman_first_name_2", 1, "warehouseman_last_name_2", "a", "062345345", "photo_warehouseman_2.png", 4, "warehouseman_2" },
                    { 13, new DateTime(1992, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "warehouseman_email_3@gmail.com", "warehouseman_first_name_3", 0, "warehouseman_last_name_3", "a", "063456789", "photo_warehouseman_3.png", 4, "warehouseman_3" },
                    { 14, new DateTime(1993, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "warehouseman_email_4@gmail.com", "warehouseman_first_name_4", 0, "warehouseman_last_name_4", "a", "064123123", "photo_warehouseman_4.png", 4, "warehouseman_4" },
                    { 15, new DateTime(1994, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "warehouseman_email_5@gmail.com", "warehouseman_first_name_5", 1, "warehouseman_last_name_5", "a", "066234567", "photo_warehouseman_5.png", 4, "warehouseman_5" },
                    { 16, new DateTime(1995, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "warehouseman_email_6@gmail.com", "warehouseman_first_name_6", 1, "warehouseman_last_name_6", "a", "063456789", "photo_warehouseman_6.png", 4, "warehouseman_6" },
                    { 17, new DateTime(1996, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "warehouseman_email_7@gmail.com", "warehouseman_first_name_7", 0, "warehouseman_last_name_7", "a", "061456789", "photo_warehouseman_7.png", 4, "warehouseman_7" },
                    { 18, new DateTime(1997, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "warehouseman_email_8@gmail.com", "warehouseman_first_name_8", 0, "warehouseman_last_name_8", "a", "069123123", "photo_warehouseman_8.png", 4, "warehouseman_8" },
                    { 21, new DateTime(1998, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "van_driver_email_1@gmail.com", "van_driver_first_name_1", 1, "van_driver_last_name_1", "a", "062111111", "photo_van_driver_1.png", 7, "van_driver_1" },
                    { 22, new DateTime(1999, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "van_driver_email_2@gmail.com", "van_driver_first_name_2", 1, "van_driver_last_name_2", "a", "062222222", "photo_van_driver_2.png", 7, "van_driver_2" },
                    { 23, new DateTime(2000, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "van_driver_email_3@gmail.com", "van_driver_first_name_3", 0, "van_driver_last_name_3", "a", "062333333", "photo_van_driver_3.png", 7, "van_driver_3" },
                    { 24, new DateTime(2001, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "van_driver_email_4@gmail.com", "van_driver_first_name_4", 0, "van_driver_last_name_4", "a", "062444444", "photo_van_driver_4.png", 7, "van_driver_4" },
                    { 333, new DateTime(1982, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "anaparovic@gmail.com", "ana", 0, "parovic", "anabanana", "061111111", "somepath", 5, "anaparovic" }
                });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "Amount", "Free", "MachineState", "Manufacturer", "Name", "Total" },
                values: new object[,]
                {
                    { 1, 150000L, 3, true, "FarmTech Industries", "Fermentation container", 5 },
                    { 2, 80000L, 7, false, "WineTech Solutions", "Pressing Machine XL", 12 },
                    { 3, 120000L, 22, true, "GrapeMaster Machinery", "Sorting Machine Pro", 54 },
                    { 4, 250000L, 0, true, "VinoTech Innovations", "Fermentation Tank V2", 5 }
                });

            migrationBuilder.InsertData(
                table: "PackingRequests",
                columns: new[] { "PackingRequestId", "CustomerOrderId", "Packed", "PackingRequestCreationDate", "PackingRequestDeadlineDate", "PackingRequestProductIds", "PackingRequestQuantities", "SectorId" },
                values: new object[,]
                {
                    { 1, 5, false, new DateTime(2024, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[1]", "[4]", 1 },
                    { 2, 5, false, new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[4]", "[10]", 2 }
                });

            migrationBuilder.InsertData(
                table: "Pricing",
                columns: new[] { "Id", "DiscountId", "Price" },
                values: new object[,]
                {
                    { 2, null, 235.99000000000001 },
                    { 3, null, 132.99000000000001 },
                    { 4, null, 72.0 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Red" },
                    { 2, "White" },
                    { 3, "Rose" }
                });

            migrationBuilder.InsertData(
                table: "RealTimeOrderTrackingStatuses",
                columns: new[] { "RealTimeOrderTrackingStatusId", "OrderTrackingStatus" },
                values: new object[,]
                {
                    { 1, "in processing" },
                    { 2, "distributed" },
                    { 3, "waiting for pick up" },
                    { 4, "ready for pick up" },
                    { 5, "picked up" },
                    { 6, "in transport" },
                    { 7, "delivered" },
                    { 8, "cancelled" }
                });

            migrationBuilder.InsertData(
                table: "Sectors",
                columns: new[] { "SectorId", "SectorImage", "SectorName", "WarehouseId", "WarehousemanId" },
                values: new object[,]
                {
                    { 1, "photo_sector_1.png", "SECTOR 1", 1, 11 },
                    { 2, "photo_sector_2.png", "SECTOR 2", 1, 12 },
                    { 3, "photo_sector_3.png", "SECTOR 3", 1, 13 },
                    { 4, "photo_sector_4.png", "SECTOR 4", 1, 14 },
                    { 5, "photo_sector_5.png", "SECTOR 5", 1, 15 },
                    { 6, "photo_sector_6.png", "SECTOR 6", 1, 16 },
                    { 7, "photo_sector_7.png", "SECTOR 7", 1, 17 },
                    { 8, "photo_sector_8.png", "SECTOR 8", 1, 18 }
                });

            migrationBuilder.InsertData(
                table: "Supplies",
                columns: new[] { "Id", "Amount", "Manufacturer", "Name", "SupplyType" },
                values: new object[,]
                {
                    { 1, 256L, "Gomex", "Grape Fertilizer 10-10-10", 0 },
                    { 2, 752L, "Gomex", "Grape Fertilizer 72456", 0 },
                    { 3, 96L, "VinoGrow Enterprises", "Vine Vitalizer 12-6-18", 0 },
                    { 4, 457L, "Harvest AgroTech", "GrapePro Nutrient Mix 16-10-14", 0 },
                    { 5, 18L, "VinoGrow Enterprises", "VineLife Essentials 10-12-18", 0 },
                    { 6, 985L, "Gomex", "GrapeGrower's Blend 8-12-20", 0 },
                    { 7, 182L, "Gomex", "Vineyard Armor Spray", 1 },
                    { 8, 445L, "VinoWarden Agrochemicals", "GrapeProtect Insecticide", 1 },
                    { 9, 32L, "VinoWarden Agrochemicals", "VineShield Pest Repellent", 1 },
                    { 10, 771L, "Harvest AgroTech", "GrapeSafe Fungicide", 1 },
                    { 11, 12L, "VinoGrow Enterprises", "VinePro Shield", 1 },
                    { 12, 658L, "Gomex", "GrapeGuardian Pest Management", 1 },
                    { 13, 10044L, "Gomex", "Zucker", 2 },
                    { 14, 444L, "Navala", "Ethanol", 3 }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "WarehouseId", "NumberOfSectors", "NumberOfVanDrivers", "NumberOfWarehouseWorkers", "WarehouseArea", "WarehouseImage", "WarehouseLocation", "WarehouseName" },
                values: new object[] { 1, 8, 5, 8, 5000.5m, "photo_warehouse.png", "Nova lokacija 123, Novi Sad", "Warehouse 1" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "CityId", "Door", "Email", "Firstname", "Floor", "Gender", "Lastname", "Number", "Password", "PhoneNumber", "Role", "Street", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "john.doe@example.com", "John", null, 1, "Doe", "101", "hashedpassword", "1234567890", 9, "123 Main St", "johndoe" },
                    { 2, new DateTime(1992, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "3", "jane.doe@example.com", "Jane", "2", 0, "Doe", "202", "hashedpassword", "9876543210", 9, "456 Elm St", "janedoe" }
                });

            migrationBuilder.InsertData(
                table: "Grapes",
                columns: new[] { "Id", "FertilizerId", "HarvestedAmount", "IsRipe", "Name", "PesticideId", "PlantingDate", "Quality", "Type" },
                values: new object[,]
                {
                    { 1, 1, 51515.0, false, "Merlot", 7, new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, true },
                    { 2, 3, 125.0, true, "Chardonnay", 10, new DateTime(2019, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, false },
                    { 3, 2, 0.0, false, "Cabernet Sauvignon", 8, new DateTime(2018, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 88, true },
                    { 4, 5, 11.0, true, "Sauvignon Blanc", 11, new DateTime(2019, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, false },
                    { 5, 6, 2666.0, true, "Syrah", 12, new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, true }
                });

            migrationBuilder.InsertData(
                table: "Pricing",
                columns: new[] { "Id", "DiscountId", "Price" },
                values: new object[] { 1, 1, 99.989999999999995 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AlcoholPercentage", "Description", "IsApproved", "Name", "PackagingSize", "Photo", "PricingId", "ProductCategoryId", "Quantity", "SectorId" },
                values: new object[,]
                {
                    { 2, 5m, "Experience the enchanting allure of Moonlit Symphony White Wine. Delicately crafted from sun-kissed grapes, this refreshing white wine captivates with its crisp acidity and vibrant fruit flavors. With hints of citrus, green apple, and tropical notes, each sip evokes a sense of serenity and sophistication. Whether enjoyed on a warm summer evening or paired with your favorite seafood dish, Moonlit Symphony is sure to elevate any occasion.", true, "Moonlit Symphony White Wine", 2.5m, "wine2.png", 2, 2, 55, 2 },
                    { 3, 5m, "Transport your senses to a blooming garden with Blush Blossom Rosé Wine. Crafted from select grapes kissed by the gentle rays of the sun, this elegant rosé captivates with its delicate pink hue and enchanting aromas of fresh strawberries and rose petals. With a balanced acidity and subtle sweetness, each sip unfolds like a bouquet of spring flowers. Whether enjoyed with light salads, creamy cheeses, or simply on its own, Blush Blossom is a celebration of life's beautiful moments.", true, "Blush Blossom Rosé Wine", 1.5m, "wine3.png", 3, 3, 25, 2 },
                    { 4, 5m, "Embark on a journey of elegance with Golden Harvest Chardonnay. Grown in sun-drenched vineyards and carefully aged in oak barrels, this exquisite white wine dazzles with its golden hue and rich, buttery texture. With flavors of ripe peach, toasted vanilla, and a hint of caramel, each sip unfolds like a symphony of indulgence. Whether paired with creamy pastas or enjoyed on its own, Golden Harvest is a testament to the artistry of winemaking.", false, "Golden Harvest Chardonnay", 1.5m, "wine3.png", 4, 2, 40, 2 },
                    { 5, 5m, "Discover the allure of Midnight Noir Cabernet Sauvignon. Born from the dark, fertile soils of our vineyards, this bold red wine entices with its deep crimson color and intense aromas of blackberries and plum. With velvety tannins and a lingering finish, each sip evokes a sense of mystery and intrigue. Whether paired with hearty stews or enjoyed on its own, Midnight Noir is a tribute to the enchantment of the night.", true, "Midnight Noir Cabernet Sauvignon", 1.5m, "wine3.png", 3, 1, 30, 1 },
                    { 6, 5m, "Awaken your senses with Sunrise Serenade Sauvignon Blanc. Harvested in the early morning light, this crisp white wine exudes freshness and vitality. With vibrant flavors of citrus, melon, and a hint of fresh-cut grass, each sip is a symphony of brightness and clarity. Whether enjoyed with light salads or seafood dishes, Sunrise Serenade is a celebration of new beginnings.", false, "Sunrise Serenade Sauvignon Blanc", 1.5m, "wine3.png", 4, 2, 50, 1 }
                });

            migrationBuilder.InsertData(
                table: "Parcels",
                columns: new[] { "Id", "Amount", "GrapeId", "Size" },
                values: new object[,]
                {
                    { 1, 5000.0, 1, 2.0 },
                    { 2, 3000.0, 2, 1.0 },
                    { 3, 7000.0, 3, 3.0 },
                    { 4, 4500.0, 4, 1.5 },
                    { 5, 6000.0, 5, 2.5 },
                    { 6, 4000.0, 1, 2.0 },
                    { 7, 5500.0, 2, 2.2999999999999998 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AlcoholPercentage", "Description", "IsApproved", "Name", "PackagingSize", "Photo", "PricingId", "ProductCategoryId", "Quantity", "SectorId" },
                values: new object[] { 1, 5m, "Indulge in the rich, velvety depths of Scarlet Elixir Red Wine. Crafted from the finest handpicked grapes, this robust red wine boasts a symphony of flavors, including notes of ripe berries, dark chocolate, and a hint of spice. Perfect for cozy evenings by the fireplace or elegant dinner parties, this wine tantalizes the palate with its smooth texture and lingering finish.", true, "Scarlet Elixir Red Wine", 1.5m, "wine1.png", 1, 1, 35, 1 });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "ActivityType", "EndDate", "IsCompleted", "ParcelId", "StartDate" },
                values: new object[,]
                {
                    { new Guid("113925c0-445e-43e9-a93b-f637017f0a16"), 2, new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2939eaf5-2f9c-4025-a94e-3301aa6e4bd8"), 1, new DateTime(2024, 5, 10, 11, 30, 0, 0, DateTimeKind.Unspecified), false, 3, new DateTime(2024, 5, 10, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("457c7ea4-278a-4498-9b54-0afcdb4a21e4"), 0, new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("80853b70-d473-4255-959a-f28f3f07a093"), 3, new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("890af017-dd80-4d2c-bc4c-4a0529d7f305"), 2, new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8a5d3c3d-6bfa-4961-8a51-3aefce33245c"), 0, new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8ce59f8f-0e78-463a-92a4-5d0b19d32fbe"), 3, new DateTime(2024, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8dcd07e9-8c30-49f9-a9f2-db4e3e57e2b7"), 3, new DateTime(2024, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("90d28159-514c-4a3d-b4cf-90396dfd96f9"), 3, new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9b0a429c-a558-4035-9357-b959a618e5b7"), 0, new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3, new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a001c2ff-a8ad-471b-8419-989cffe4db6e"), 0, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b54b6d50-a4a7-4883-ac7c-383e0c775f8e"), 2, new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c229e865-4d1b-4039-9559-20e04529856b"), 3, new DateTime(2024, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c8f78e77-2dc4-4280-bbd5-167df48aa94d"), 0, new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d4c79492-cb05-4a23-90b1-e356a4f8811e"), 2, new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dd345f77-c209-4c97-9146-00a6224e9eb5"), 1, new DateTime(2024, 5, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 5, new DateTime(2024, 5, 20, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("df441ed7-d7c8-47a2-b99a-07766aea7232"), 1, new DateTime(2024, 5, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), false, 4, new DateTime(2024, 5, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e4d77849-2023-4fdd-b468-a74c6df8fd98"), 1, new DateTime(2024, 5, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), false, 2, new DateTime(2024, 5, 5, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ee5f39a5-f489-4003-a387-cd9a88bf1a9d"), 1, new DateTime(2024, 5, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), false, 1, new DateTime(2024, 5, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fb2a1b7f-bdd0-40da-829c-7cc562415080"), 2, new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Fertilizations",
                columns: new[] { "Id", "Amount", "FertilizerId" },
                values: new object[,]
                {
                    { new Guid("113925c0-445e-43e9-a93b-f637017f0a16"), 1500L, 1 },
                    { new Guid("890af017-dd80-4d2c-bc4c-4a0529d7f305"), 1000L, 1 },
                    { new Guid("b54b6d50-a4a7-4883-ac7c-383e0c775f8e"), 1200L, 3 },
                    { new Guid("d4c79492-cb05-4a23-90b1-e356a4f8811e"), 800L, 2 },
                    { new Guid("fb2a1b7f-bdd0-40da-829c-7cc562415080"), 2000L, 2 }
                });

            migrationBuilder.InsertData(
                table: "Harvestings",
                columns: new[] { "Id", "Amount" },
                values: new object[,]
                {
                    { new Guid("457c7ea4-278a-4498-9b54-0afcdb4a21e4"), 12000L },
                    { new Guid("8a5d3c3d-6bfa-4961-8a51-3aefce33245c"), 10500L },
                    { new Guid("9b0a429c-a558-4035-9357-b959a618e5b7"), 15000L },
                    { new Guid("a001c2ff-a8ad-471b-8419-989cffe4db6e"), 9000L },
                    { new Guid("c8f78e77-2dc4-4280-bbd5-167df48aa94d"), 13500L }
                });

            migrationBuilder.InsertData(
                table: "PesticideControls",
                columns: new[] { "Id", "Amount", "PesticideId" },
                values: new object[,]
                {
                    { new Guid("80853b70-d473-4255-959a-f28f3f07a093"), 700L, 2 },
                    { new Guid("8ce59f8f-0e78-463a-92a4-5d0b19d32fbe"), 500L, 1 },
                    { new Guid("8dcd07e9-8c30-49f9-a9f2-db4e3e57e2b7"), 1000L, 3 },
                    { new Guid("90d28159-514c-4a3d-b4cf-90396dfd96f9"), 1200L, 1 },
                    { new Guid("c229e865-4d1b-4039-9559-20e04529856b"), 1500L, 2 }
                });

            migrationBuilder.InsertData(
                table: "Waterings",
                columns: new[] { "Id", "Amount" },
                values: new object[,]
                {
                    { new Guid("2939eaf5-2f9c-4025-a94e-3301aa6e4bd8"), 6000L },
                    { new Guid("dd345f77-c209-4c97-9146-00a6224e9eb5"), 4500L },
                    { new Guid("df441ed7-d7c8-47a2-b99a-07766aea7232"), 5500L },
                    { new Guid("e4d77849-2023-4fdd-b468-a74c6df8fd98"), 7000L },
                    { new Guid("ee5f39a5-f489-4003-a387-cd9a88bf1a9d"), 5000L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ParcelId",
                table: "Activities",
                column: "ParcelId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CityId",
                table: "Customers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Fermentations_GrapeId",
                table: "Fermentations",
                column: "GrapeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fertilizations_FertilizerId",
                table: "Fertilizations",
                column: "FertilizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Grapes_FertilizerId",
                table: "Grapes",
                column: "FertilizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Grapes_PesticideId",
                table: "Grapes",
                column: "PesticideId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_GrapeId",
                table: "Parcels",
                column: "GrapeId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticideControls_PesticideId",
                table: "PesticideControls",
                column: "PesticideId");

            migrationBuilder.CreateIndex(
                name: "IX_Pricing_DiscountId",
                table: "Pricing",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PricingId",
                table: "Products",
                column: "PricingId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "CustomerOrders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Fermentations");

            migrationBuilder.DropTable(
                name: "Fertilizations");

            migrationBuilder.DropTable(
                name: "Harvestings");

            migrationBuilder.DropTable(
                name: "Logisticians");

            migrationBuilder.DropTable(
                name: "MachineOrders");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "MarketingManagers");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "PackingRequests");

            migrationBuilder.DropTable(
                name: "PesticideControls");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RealTimeOrderTrackingStatuses");

            migrationBuilder.DropTable(
                name: "SalesManagers");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropTable(
                name: "SupplierProducts");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "SupplyOrders");

            migrationBuilder.DropTable(
                name: "Technologists");

            migrationBuilder.DropTable(
                name: "TourGuides");

            migrationBuilder.DropTable(
                name: "TransportRequests");

            migrationBuilder.DropTable(
                name: "VanDrivers");

            migrationBuilder.DropTable(
                name: "Warehousemen");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Waterings");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Pricing");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Parcels");

            migrationBuilder.DropTable(
                name: "Grapes");

            migrationBuilder.DropTable(
                name: "Supplies");
        }
    }
}
