using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LectureSpacesApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cuestionario",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripicion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuestionario", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LectureSpaceComponent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    videoID = table.Column<int>(type: "int", nullable: true),
                    cuestionarioID = table.Column<int>(type: "int", nullable: true),
                    UsuarioID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureSpaceComponent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LectureSpaceComponent_Cuestionario_cuestionarioID",
                        column: x => x.cuestionarioID,
                        principalTable: "Cuestionario",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_LectureSpaceComponent_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_LectureSpaceComponent_Video_videoID",
                        column: x => x.videoID,
                        principalTable: "Video",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Recurso",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contenido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    LectureSpaceComponentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recurso", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recurso_LectureSpaceComponent_LectureSpaceComponentID",
                        column: x => x.LectureSpaceComponentID,
                        principalTable: "LectureSpaceComponent",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Pregunta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    enunciado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correctaID = table.Column<int>(type: "int", nullable: true),
                    votos = table.Column<int>(type: "int", nullable: false),
                    CuestionarioID = table.Column<int>(type: "int", nullable: true),
                    UsuarioID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregunta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pregunta_Cuestionario_CuestionarioID",
                        column: x => x.CuestionarioID,
                        principalTable: "Cuestionario",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Pregunta_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Respuesta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contenido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreguntaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuesta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Respuesta_Pregunta_PreguntaID",
                        column: x => x.PreguntaID,
                        principalTable: "Pregunta",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LectureSpaceComponent_cuestionarioID",
                table: "LectureSpaceComponent",
                column: "cuestionarioID");

            migrationBuilder.CreateIndex(
                name: "IX_LectureSpaceComponent_UsuarioID",
                table: "LectureSpaceComponent",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_LectureSpaceComponent_videoID",
                table: "LectureSpaceComponent",
                column: "videoID");

            migrationBuilder.CreateIndex(
                name: "IX_Pregunta_correctaID",
                table: "Pregunta",
                column: "correctaID");

            migrationBuilder.CreateIndex(
                name: "IX_Pregunta_CuestionarioID",
                table: "Pregunta",
                column: "CuestionarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Pregunta_UsuarioID",
                table: "Pregunta",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Recurso_LectureSpaceComponentID",
                table: "Recurso",
                column: "LectureSpaceComponentID");

            migrationBuilder.CreateIndex(
                name: "IX_Respuesta_PreguntaID",
                table: "Respuesta",
                column: "PreguntaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pregunta_Respuesta_correctaID",
                table: "Pregunta",
                column: "correctaID",
                principalTable: "Respuesta",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pregunta_Cuestionario_CuestionarioID",
                table: "Pregunta");

            migrationBuilder.DropForeignKey(
                name: "FK_Pregunta_Usuario_UsuarioID",
                table: "Pregunta");

            migrationBuilder.DropForeignKey(
                name: "FK_Pregunta_Respuesta_correctaID",
                table: "Pregunta");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Recurso");

            migrationBuilder.DropTable(
                name: "LectureSpaceComponent");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "Cuestionario");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Respuesta");

            migrationBuilder.DropTable(
                name: "Pregunta");
        }
    }
}
