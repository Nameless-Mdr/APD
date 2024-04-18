using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APD.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "main");

            migrationBuilder.CreateTable(
                name: "Office",
                schema: "main",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeConnect",
                schema: "main",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeConnect", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "main",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Office_OfficeId",
                        column: x => x.OfficeId,
                        principalSchema: "main",
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrintDevice",
                schema: "main",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeConnectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintDevice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrintDevice_TypeConnect_TypeConnectId",
                        column: x => x.TypeConnectId,
                        principalSchema: "main",
                        principalTable: "TypeConnect",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Installation",
                schema: "main",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SequenceNumber = table.Column<int>(type: "int", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    PrintDeviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Installation_Office_OfficeId",
                        column: x => x.OfficeId,
                        principalSchema: "main",
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Installation_PrintDevice_PrintDeviceId",
                        column: x => x.PrintDeviceId,
                        principalSchema: "main",
                        principalTable: "PrintDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Installation_OfficeId",
                schema: "main",
                table: "Installation",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Installation_PrintDeviceId",
                schema: "main",
                table: "Installation",
                column: "PrintDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_PrintDevice_TypeConnectId",
                schema: "main",
                table: "PrintDevice",
                column: "TypeConnectId");

            migrationBuilder.CreateIndex(
                name: "IX_User_OfficeId",
                schema: "main",
                table: "User",
                column: "OfficeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Installation",
                schema: "main");

            migrationBuilder.DropTable(
                name: "User",
                schema: "main");

            migrationBuilder.DropTable(
                name: "PrintDevice",
                schema: "main");

            migrationBuilder.DropTable(
                name: "Office",
                schema: "main");

            migrationBuilder.DropTable(
                name: "TypeConnect",
                schema: "main");
        }
    }
}
