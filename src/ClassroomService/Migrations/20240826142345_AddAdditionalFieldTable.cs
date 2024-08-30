using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassroomService.Migrations
{
    /// <inheritdoc />
    public partial class AddAdditionalFieldTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "additional_field",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    data_type = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    value = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_additional_field", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "classroom_has_additional_field",
                columns: table => new
                {
                    AdditionalFieldsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassroomsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classroom_has_additional_field", x => new { x.AdditionalFieldsId, x.ClassroomsId });
                    table.ForeignKey(
                        name: "FK_classroom_has_additional_field_additional_field_AdditionalF~",
                        column: x => x.AdditionalFieldsId,
                        principalTable: "additional_field",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classroom_has_additional_field_classroom_ClassroomsId",
                        column: x => x.ClassroomsId,
                        principalTable: "classroom",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_classroom_has_additional_field_ClassroomsId",
                table: "classroom_has_additional_field",
                column: "ClassroomsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "classroom_has_additional_field");

            migrationBuilder.DropTable(
                name: "additional_field");
        }
    }
}
