using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using AngularApp.DAL.Contexts;

namespace AngularApp.DAL.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20160327160631_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AngularApp.DAL.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("AngularApp.DAL.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<bool>("IsAvailable");

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("AngularApp.DAL.Entities.Product", b =>
                {
                    b.HasOne("AngularApp.DAL.Entities.Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });
        }
    }
}
