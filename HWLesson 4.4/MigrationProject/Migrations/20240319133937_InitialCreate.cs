using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "category",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "location",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    location_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "breed",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    breed_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_breed", x => x.id);
                    table.ForeignKey(
                        name: "FK_breed_category_category_id",
                        column: x => x.category_id,
                        principalSchema: "dbo",
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pet",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    breed_id = table.Column<int>(type: "int", nullable: false),
                    age = table.Column<float>(type: "real", nullable: false),
                    location_id = table.Column<int>(type: "int", nullable: false),
                    image_url = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pet", x => x.id);
                    table.ForeignKey(
                        name: "FK_pet_breed_breed_id",
                        column: x => x.breed_id,
                        principalSchema: "dbo",
                        principalTable: "breed",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_pet_category_category_id",
                        column: x => x.category_id,
                        principalSchema: "dbo",
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pet_location_location_id",
                        column: x => x.location_id,
                        principalSchema: "dbo",
                        principalTable: "location",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_breed_category_id",
                schema: "dbo",
                table: "breed",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_pet_breed_id",
                schema: "dbo",
                table: "pet",
                column: "breed_id");

            migrationBuilder.CreateIndex(
                name: "IX_pet_category_id",
                schema: "dbo",
                table: "pet",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_pet_location_id",
                schema: "dbo",
                table: "pet",
                column: "location_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pet",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "breed",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "location",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "category",
                schema: "dbo");
        }
    }
}
