using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace _1_Infra.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumItem = table.Column<int>(type: "integer", nullable: false),
                    Grupo = table.Column<string>(type: "text", nullable: true),
                    SubGrupo = table.Column<string>(type: "text", nullable: true),
                    CentroDeCusto = table.Column<string>(type: "text", nullable: true),
                    ItemDesc = table.Column<string>(type: "text", nullable: true),
                    Localizacao = table.Column<string>(type: "text", nullable: true),
                    Frota = table.Column<string>(type: "text", nullable: true),
                    TaxaDepreciacao = table.Column<int>(type: "integer", nullable: false),
                    VidaUtilEstimada = table.Column<int>(type: "integer", nullable: false),
                    NotaFiscalEntrada = table.Column<int>(type: "integer", nullable: false),
                    Fornecedor = table.Column<string>(type: "text", nullable: true),
                    DataEntrada = table.Column<string>(type: "text", nullable: true),
                    DataEmissao = table.Column<string>(type: "text", nullable: true),
                    ValorAquisicao = table.Column<int>(type: "integer", nullable: false),
                    ICMS = table.Column<int>(type: "integer", nullable: false),
                    PIS = table.Column<int>(type: "integer", nullable: false),
                    COFINS = table.Column<int>(type: "integer", nullable: false),
                    CIAP = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");
        }
    }
}
