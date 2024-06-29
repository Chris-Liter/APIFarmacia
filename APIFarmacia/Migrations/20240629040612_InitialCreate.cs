using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace APIFarmacia.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    cedula = table.Column<string>(type: "text", nullable: false),
                    fechaNacimiento = table.Column<string>(type: "text", nullable: false),
                    correo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Facturas",
                columns: table => new
                {
                    det_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    det_cantidad = table.Column<int>(type: "integer", nullable: false),
                    det_precio_unitario = table.Column<double>(type: "double precision", nullable: false),
                    det_subtotal = table.Column<double>(type: "double precision", nullable: false),
                    det_iva = table.Column<double>(type: "double precision", nullable: false),
                    det_total = table.Column<double>(type: "double precision", nullable: false),
                    producto_id = table.Column<int>(type: "integer", nullable: false),
                    factura_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Facturas", x => x.det_id);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    fac_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fac_tipo = table.Column<int>(type: "integer", nullable: false),
                    fac_fecha = table.Column<string>(type: "text", nullable: false),
                    fac_subTotal = table.Column<double>(type: "double precision", nullable: false),
                    fac_total_iva = table.Column<double>(type: "double precision", nullable: false),
                    fac_total = table.Column<double>(type: "double precision", nullable: false),
                    id_cliente = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.fac_id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigo_producto = table.Column<string>(type: "text", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    precio = table.Column<double>(type: "double precision", nullable: false),
                    stock = table.Column<int>(type: "integer", nullable: false),
                    iva = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    fechanacimiento = table.Column<string>(type: "text", nullable: false),
                    passwords = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Detalle_Facturas");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
