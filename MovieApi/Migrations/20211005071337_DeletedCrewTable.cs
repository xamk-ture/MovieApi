using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApi.Migrations
{
    public partial class DeletedCrewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crews",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActorId = table.Column<long>(type: "bigint", nullable: true),
                    DirectorId = table.Column<long>(type: "bigint", nullable: true),
                    MovieId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crews_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Crews_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Crews_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crews_ActorId",
                table: "Crews",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Crews_DirectorId",
                table: "Crews",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Crews_MovieId",
                table: "Crews",
                column: "MovieId");
        }
    }
}
