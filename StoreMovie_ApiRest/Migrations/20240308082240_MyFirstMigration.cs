using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreMovie_ApiRest.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieGenders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "moviesStores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameMovie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    MovieGenderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moviesStores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_moviesStores_MovieGenders_MovieGenderId",
                        column: x => x.MovieGenderId,
                        principalTable: "MovieGenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserStores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CellPhone = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false),
                    MoviesStoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserStores_moviesStores_MoviesStoreId",
                        column: x => x.MoviesStoreId,
                        principalTable: "moviesStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_moviesStores_MovieGenderId",
                table: "moviesStores",
                column: "MovieGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStores_MoviesStoreId",
                table: "UserStores",
                column: "MoviesStoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserStores");

            migrationBuilder.DropTable(
                name: "moviesStores");

            migrationBuilder.DropTable(
                name: "MovieGenders");
        }
    }
}
