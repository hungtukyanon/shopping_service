// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using shopping_services.Data;

#nullable disable

namespace shoppingservices.Migrations
{
    [DbContext(typeof(FE_DbContext))]
    [Migration("20221129145403_updateUser")]
    partial class updateUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("shopping_services.Data.Category", b =>
                {
                    b.Property<Guid>("category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("product_id")
                        .HasColumnType("uuid");

                    b.HasKey("category_id");

                    b.HasIndex("product_id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("shopping_services.Data.Order", b =>
                {
                    b.Property<Guid>("order_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("deliveryAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("deliveryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("orderStatus")
                        .HasColumnType("integer");

                    b.Property<string>("orderer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("order_id");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("shopping_services.Data.OrderDetail", b =>
                {
                    b.Property<Guid>("order_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("product_id")
                        .HasColumnType("uuid");

                    b.Property<byte>("discount")
                        .HasColumnType("smallint");

                    b.Property<int>("quantity")
                        .HasColumnType("integer");

                    b.Property<double>("totalMoney")
                        .HasColumnType("double precision");

                    b.HasKey("order_id", "product_id");

                    b.HasIndex("product_id");

                    b.ToTable("OrderDetail", (string)null);
                });

            modelBuilder.Entity("shopping_services.Data.Product", b =>
                {
                    b.Property<Guid>("product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("category_id")
                        .HasColumnType("uuid");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<byte?>("discount")
                        .HasColumnType("smallint");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("price")
                        .HasColumnType("double precision");

                    b.HasKey("product_id");

                    b.HasIndex("category_id");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("shopping_services.Data.User", b =>
                {
                    b.Property<Guid>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("RefresherToken")
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("user_id");

                    b.HasIndex("username")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("shopping_services.Data.Category", b =>
                {
                    b.HasOne("shopping_services.Data.Product", "Product")
                        .WithMany("Categories")
                        .HasForeignKey("product_id");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("shopping_services.Data.OrderDetail", b =>
                {
                    b.HasOne("shopping_services.Data.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("order_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("shopping_services.Data.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("shopping_services.Data.Product", b =>
                {
                    b.HasOne("shopping_services.Data.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("category_id");
                });

            modelBuilder.Entity("shopping_services.Data.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("shopping_services.Data.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("shopping_services.Data.Product", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
