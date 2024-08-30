using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassroomService.Migrations
{
    /// <inheritdoc />
    public partial class FixAdditionalField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_classroom_has_additional_field_additional_field_AdditionalF~",
                table: "classroom_has_additional_field");

            migrationBuilder.DropForeignKey(
                name: "FK_classroom_has_additional_field_classroom_ClassroomsId",
                table: "classroom_has_additional_field");

            migrationBuilder.DropColumn(
                name: "value",
                table: "additional_field");

            migrationBuilder.RenameColumn(
                name: "ClassroomsId",
                table: "classroom_has_additional_field",
                newName: "classroom_id");

            migrationBuilder.RenameColumn(
                name: "AdditionalFieldsId",
                table: "classroom_has_additional_field",
                newName: "additional_field_id");

            migrationBuilder.RenameIndex(
                name: "IX_classroom_has_additional_field_ClassroomsId",
                table: "classroom_has_additional_field",
                newName: "IX_classroom_has_additional_field_classroom_id");

            migrationBuilder.AddColumn<string>(
                name: "value",
                table: "classroom_has_additional_field",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_classroom_has_additional_field_additional_field_additional_~",
                table: "classroom_has_additional_field",
                column: "additional_field_id",
                principalTable: "additional_field",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_classroom_has_additional_field_classroom_classroom_id",
                table: "classroom_has_additional_field",
                column: "classroom_id",
                principalTable: "classroom",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_classroom_has_additional_field_additional_field_additional_~",
                table: "classroom_has_additional_field");

            migrationBuilder.DropForeignKey(
                name: "FK_classroom_has_additional_field_classroom_classroom_id",
                table: "classroom_has_additional_field");

            migrationBuilder.DropColumn(
                name: "value",
                table: "classroom_has_additional_field");

            migrationBuilder.RenameColumn(
                name: "classroom_id",
                table: "classroom_has_additional_field",
                newName: "ClassroomsId");

            migrationBuilder.RenameColumn(
                name: "additional_field_id",
                table: "classroom_has_additional_field",
                newName: "AdditionalFieldsId");

            migrationBuilder.RenameIndex(
                name: "IX_classroom_has_additional_field_classroom_id",
                table: "classroom_has_additional_field",
                newName: "IX_classroom_has_additional_field_ClassroomsId");

            migrationBuilder.AddColumn<string>(
                name: "value",
                table: "additional_field",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_classroom_has_additional_field_additional_field_AdditionalF~",
                table: "classroom_has_additional_field",
                column: "AdditionalFieldsId",
                principalTable: "additional_field",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_classroom_has_additional_field_classroom_ClassroomsId",
                table: "classroom_has_additional_field",
                column: "ClassroomsId",
                principalTable: "classroom",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
