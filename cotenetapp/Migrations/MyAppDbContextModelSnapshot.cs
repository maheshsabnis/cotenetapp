﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cotenetapp.Models;

namespace cotenetapp.Migrations
{
    [DbContext(typeof(MyAppDbContext))]
    partial class MyAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("cotenetapp.Models.Category", b =>
                {
                    b.Property<int>("CategoryRowId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BasePrice");

                    b.Property<string>("CategoryId")
                        .IsRequired();

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("CategoryRowId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("cotenetapp.Models.Product", b =>
                {
                    b.Property<int>("ProductRowId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryRowId");

                    b.Property<string>("Manufacturer")
                        .IsRequired();

                    b.Property<int>("Price");

                    b.Property<string>("ProductId")
                        .IsRequired();

                    b.Property<string>("ProductName")
                        .IsRequired();

                    b.HasKey("ProductRowId");

                    b.HasIndex("CategoryRowId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("cotenetapp.Models.Product", b =>
                {
                    b.HasOne("cotenetapp.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryRowId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
