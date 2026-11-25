using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cat_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "int", nullable: false),
                    aid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.book_id, x.aid });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_aid",
                        column: x => x.aid,
                        principalTable: "Authors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    shcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    pid = table.Column<int>(type: "int", nullable: false),
                    cat_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Books_Categories_cat_id",
                        column: x => x.cat_id,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_pid",
                        column: x => x.pid,
                        principalTable: "Publishers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Borrows",
                columns: table => new
                {
                    Emp_id = table.Column<int>(type: "int", nullable: false),
                    book_id = table.Column<int>(type: "int", nullable: false),
                    SSN = table.Column<int>(type: "int", nullable: false),
                    date_borrowed = table.Column<DateTime>(type: "date", nullable: false),
                    due_date = table.Column<DateTime>(type: "date", nullable: false),
                    amountofmoney = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrows", x => new { x.Emp_id, x.book_id, x.SSN, x.date_borrowed });
                    table.ForeignKey(
                        name: "FK_Borrows_Books_book_id",
                        column: x => x.book_id,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Emp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Bouns = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    SupervisorId = table.Column<int>(type: "int", nullable: true),
                    floor_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Emp_id);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Employees",
                        principalColumn: "Emp_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    floor_number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfBlocks = table.Column<int>(type: "int", nullable: false),
                    manage_id = table.Column<int>(type: "int", nullable: true),
                    Hiring_date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.floor_number);
                    table.ForeignKey(
                        name: "FK_Floors_Employees_manage_id",
                        column: x => x.manage_id,
                        principalTable: "Employees",
                        principalColumn: "Emp_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    SSN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.SSN);
                    table.ForeignKey(
                        name: "FK_Users_Employees_record_id",
                        column: x => x.record_id,
                        principalTable: "Employees",
                        principalColumn: "Emp_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shelves",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    floor_num = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelves", x => x.code);
                    table.ForeignKey(
                        name: "FK_Shelves_Floors_floor_num",
                        column: x => x.floor_num,
                        principalTable: "Floors",
                        principalColumn: "floor_number",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPhones",
                columns: table => new
                {
                    user_ssn = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhones", x => new { x.user_ssn, x.Phone });
                    table.ForeignKey(
                        name: "FK_UserPhones_Users_user_ssn",
                        column: x => x.user_ssn,
                        principalTable: "Users",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_aid",
                table: "BookAuthors",
                column: "aid");

            migrationBuilder.CreateIndex(
                name: "IX_Books_cat_id",
                table: "Books",
                column: "cat_id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_pid",
                table: "Books",
                column: "pid");

            migrationBuilder.CreateIndex(
                name: "IX_Books_shcode",
                table: "Books",
                column: "shcode");

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_book_id",
                table: "Borrows",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_SSN",
                table: "Borrows",
                column: "SSN");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_floor_id",
                table: "Employees",
                column: "floor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SupervisorId",
                table: "Employees",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Floors_manage_id",
                table: "Floors",
                column: "manage_id");

            migrationBuilder.CreateIndex(
                name: "IX_Shelves_floor_num",
                table: "Shelves",
                column: "floor_num");

            migrationBuilder.CreateIndex(
                name: "IX_Users_record_id",
                table: "Users",
                column: "record_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Books_book_id",
                table: "BookAuthors",
                column: "book_id",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Shelves_shcode",
                table: "Books",
                column: "shcode",
                principalTable: "Shelves",
                principalColumn: "code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Employees_Emp_id",
                table: "Borrows",
                column: "Emp_id",
                principalTable: "Employees",
                principalColumn: "Emp_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Users_SSN",
                table: "Borrows",
                column: "SSN",
                principalTable: "Users",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Floors_floor_id",
                table: "Employees",
                column: "floor_id",
                principalTable: "Floors",
                principalColumn: "floor_number",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Floors_Employees_manage_id",
                table: "Floors");

            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "Borrows");

            migrationBuilder.DropTable(
                name: "UserPhones");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Shelves");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Floors");
        }
    }
}
