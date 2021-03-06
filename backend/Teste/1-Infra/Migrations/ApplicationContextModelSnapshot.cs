// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Teste.Infra;

namespace _1_Infra.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Teste.Domain.Entidades.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("CIAP")
                        .HasColumnType("boolean");

                    b.Property<int>("COFINS")
                        .HasColumnType("integer");

                    b.Property<string>("CentroDeCusto")
                        .HasColumnType("text");

                    b.Property<string>("DataEmissao")
                        .HasColumnType("text");

                    b.Property<string>("DataEntrada")
                        .HasColumnType("text");

                    b.Property<string>("Fornecedor")
                        .HasColumnType("text");

                    b.Property<string>("Frota")
                        .HasColumnType("text");

                    b.Property<string>("Grupo")
                        .HasColumnType("text");

                    b.Property<int>("ICMS")
                        .HasColumnType("integer");

                    b.Property<string>("Imagem")
                        .HasColumnType("text");

                    b.Property<bool>("IsValidated")
                        .HasColumnType("boolean");

                    b.Property<string>("ItemDesc")
                        .HasColumnType("text");

                    b.Property<string>("Localizacao")
                        .HasColumnType("text");

                    b.Property<int>("NotaFiscalEntrada")
                        .HasColumnType("integer");

                    b.Property<int>("NumItem")
                        .HasColumnType("integer");

                    b.Property<int>("PIS")
                        .HasColumnType("integer");

                    b.Property<string>("SubGrupo")
                        .HasColumnType("text");

                    b.Property<int>("TaxaDepreciacao")
                        .HasColumnType("integer");

                    b.Property<int>("ValorAquisicao")
                        .HasColumnType("integer");

                    b.Property<int>("VidaUtilEstimada")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
