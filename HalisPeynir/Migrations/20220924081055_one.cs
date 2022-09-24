using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HalisPeynir.Migrations
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    JobTitleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitleName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.JobTitleID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "Servicees",
                columns: table => new
                {
                    ServiceeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicees", x => x.ServiceeID);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    ShiftID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.ShiftID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAndSecName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderID = table.Column<int>(type: "int", nullable: false),
                    JobTitleID = table.Column<int>(type: "int", nullable: false),
                    ShiftID = table.Column<int>(type: "int", nullable: false),
                    WorkStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Genders_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Genders",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_JobTitles_JobTitleID",
                        column: x => x.JobTitleID,
                        principalTable: "JobTitles",
                        principalColumn: "JobTitleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Shifts_ShiftID",
                        column: x => x.ShiftID,
                        principalTable: "Shifts",
                        principalColumn: "ShiftID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderID", "GenderName" },
                values: new object[,]
                {
                    { 1, "Female" },
                    { 2, "Male" },
                    { 3, "I don't wanna choose" }
                });

            migrationBuilder.InsertData(
                table: "JobTitles",
                columns: new[] { "JobTitleID", "JobTitleName" },
                values: new object[,]
                {
                    { 1, "Techinician" },
                    { 2, "Master" },
                    { 3, "Director" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Ezine Sert 600 gr", 60m },
                    { 2, "Ezine Sert 350 gr", 20m },
                    { 3, "Ezine Sert 150 gr", 15m },
                    { 4, "Ezine Sert 400 gr", 50m }
                });

            migrationBuilder.InsertData(
                table: "Servicees",
                columns: new[] { "ServiceeID", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Service 1", 70m },
                    { 2, "Service 2", 40m },
                    { 3, "Service 3", 55m },
                    { 4, "Service 4", 90m }
                });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "ShiftID", "ShiftName" },
                values: new object[,]
                {
                    { 1, "Morning" },
                    { 2, "Evening" },
                    { 3, "Night" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "DOB", "GenderID", "JobTitleID", "NameAndSecName", "ShiftID", "Surname", "WorkStatus" },
                values: new object[] { 1, new DateTime(2001, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Bob", 1, "Taylor", true });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "DOB", "GenderID", "JobTitleID", "NameAndSecName", "ShiftID", "Surname", "WorkStatus" },
                values: new object[] { 2, new DateTime(2002, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Michael", 2, "Blanch", false });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "DOB", "GenderID", "JobTitleID", "NameAndSecName", "ShiftID", "Surname", "WorkStatus" },
                values: new object[] { 3, new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, "Leyla", 3, "Green", true });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GenderID",
                table: "Employees",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobTitleID",
                table: "Employees",
                column: "JobTitleID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ShiftID",
                table: "Employees",
                column: "ShiftID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Servicees");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.DropTable(
                name: "Shifts");
        }
    }
}
