using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClassLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Ideals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ideals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Mov_1 = table.Column<string>(type: "text", nullable: true),
                    Mov_2 = table.Column<string>(type: "text", nullable: true),
                    Desc = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideals", x => x.Id);
                });
            using (ApplicationContext db = new ApplicationContext())
            {
                Ideal volya = new Ideal { Id = 1, Name = "Воля", Mov_1 = "Черный", Mov_2 = "Зеленый", Desc = "Воля або смерть!" };
                Ideal poryadok = new Ideal { Id = 1, Name = "Порядок", Mov_1 = "Красный", Mov_2 = "Белый", Desc = "Порядок привыше всего" };
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ideals");
        }
    }
}
