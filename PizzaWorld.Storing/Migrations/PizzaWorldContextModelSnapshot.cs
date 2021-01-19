﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaWorld.Storing;

namespace PizzaWorld.Storing.Migrations
{
    [DbContext(typeof(PizzaWorldContext))]
    partial class PizzaWorldContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("APizzaModelOrder", b =>
                {
                    b.Property<long>("OrdersEntityID")
                        .HasColumnType("bigint");

                    b.Property<long>("PizzasEntityID")
                        .HasColumnType("bigint");

                    b.HasKey("OrdersEntityID", "PizzasEntityID");

                    b.HasIndex("PizzasEntityID");

                    b.ToTable("APizzaModelOrder");
                });

            modelBuilder.Entity("APizzaModelTopping", b =>
                {
                    b.Property<long>("PizzasEntityID")
                        .HasColumnType("bigint");

                    b.Property<long>("ToppingsEntityID")
                        .HasColumnType("bigint");

                    b.HasKey("PizzasEntityID", "ToppingsEntityID");

                    b.HasIndex("ToppingsEntityID");

                    b.ToTable("APizzaModelTopping");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Abstracts.APizzaModel", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("CrustEntityID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<long?>("SizeEntityID")
                        .HasColumnType("bigint");

                    b.HasKey("EntityID");

                    b.HasIndex("CrustEntityID");

                    b.HasIndex("SizeEntityID");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Crust", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("EntityID");

                    b.ToTable("Crusts");

                    b.HasData(
                        new
                        {
                            EntityID = 1L,
                            Name = "Thin",
                            Price = 0.0
                        },
                        new
                        {
                            EntityID = 2L,
                            Name = "Hand Tossed",
                            Price = 0.0
                        },
                        new
                        {
                            EntityID = 3L,
                            Name = "Cheese-Stuffed",
                            Price = 2.0
                        });
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Customer", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SelectedStoreEntityID")
                        .HasColumnType("bigint");

                    b.HasKey("EntityID");

                    b.HasIndex("SelectedStoreEntityID");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            EntityID = 1L,
                            Name = "Elmer"
                        },
                        new
                        {
                            EntityID = 2L,
                            Name = "Elmer2"
                        },
                        new
                        {
                            EntityID = 3L,
                            Name = "user3"
                        });
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Order", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("CustomerEntityID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Ordertime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<long?>("StoreEntityID")
                        .HasColumnType("bigint");

                    b.HasKey("EntityID");

                    b.HasIndex("CustomerEntityID");

                    b.HasIndex("StoreEntityID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.PrebuiltPizza", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("CrustEntityID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<long?>("SizeEntityID")
                        .HasColumnType("bigint");

                    b.HasKey("EntityID");

                    b.HasIndex("CrustEntityID");

                    b.HasIndex("SizeEntityID");

                    b.ToTable("PrebuiltPizzas");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Size", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("EntityID");

                    b.ToTable("Sizes");

                    b.HasData(
                        new
                        {
                            EntityID = 1L,
                            Name = "Small",
                            Price = 0.0
                        },
                        new
                        {
                            EntityID = 2L,
                            Name = "Medium",
                            Price = 3.0
                        },
                        new
                        {
                            EntityID = 3L,
                            Name = "Large",
                            Price = 5.0
                        });
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Store", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityID");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            EntityID = 1L,
                            Address = "Store 1 Address",
                            Name = "One"
                        },
                        new
                        {
                            EntityID = 2L,
                            Address = "Store 2 Address",
                            Name = "Two"
                        },
                        new
                        {
                            EntityID = 3L,
                            Address = "Store 3 Address",
                            Name = "Three"
                        });
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Topping", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("EntityID");

                    b.ToTable("Toppings");

                    b.HasData(
                        new
                        {
                            EntityID = 1L,
                            Name = "Cheese",
                            Price = 0.0
                        },
                        new
                        {
                            EntityID = 2L,
                            Name = "Premium Chicken",
                            Price = 2.0
                        },
                        new
                        {
                            EntityID = 3L,
                            Name = "Pulled Pork",
                            Price = 2.0
                        },
                        new
                        {
                            EntityID = 4L,
                            Name = "Mushroom",
                            Price = 0.0
                        },
                        new
                        {
                            EntityID = 5L,
                            Name = "Ham",
                            Price = 1.0
                        },
                        new
                        {
                            EntityID = 6L,
                            Name = "Pineapple",
                            Price = 1.0
                        });
                });

            modelBuilder.Entity("PrebuiltPizzaTopping", b =>
                {
                    b.Property<long>("PrebuiltPizzasEntityID")
                        .HasColumnType("bigint");

                    b.Property<long>("ToppingsEntityID")
                        .HasColumnType("bigint");

                    b.HasKey("PrebuiltPizzasEntityID", "ToppingsEntityID");

                    b.HasIndex("ToppingsEntityID");

                    b.ToTable("PrebuiltPizzaTopping");
                });

            modelBuilder.Entity("APizzaModelOrder", b =>
                {
                    b.HasOne("PizzaWorld.Domain.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaWorld.Domain.Abstracts.APizzaModel", null)
                        .WithMany()
                        .HasForeignKey("PizzasEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APizzaModelTopping", b =>
                {
                    b.HasOne("PizzaWorld.Domain.Abstracts.APizzaModel", null)
                        .WithMany()
                        .HasForeignKey("PizzasEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaWorld.Domain.Models.Topping", null)
                        .WithMany()
                        .HasForeignKey("ToppingsEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaWorld.Domain.Abstracts.APizzaModel", b =>
                {
                    b.HasOne("PizzaWorld.Domain.Models.Crust", "Crust")
                        .WithMany()
                        .HasForeignKey("CrustEntityID");

                    b.HasOne("PizzaWorld.Domain.Models.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeEntityID");

                    b.Navigation("Crust");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Customer", b =>
                {
                    b.HasOne("PizzaWorld.Domain.Models.Store", "SelectedStore")
                        .WithMany()
                        .HasForeignKey("SelectedStoreEntityID");

                    b.Navigation("SelectedStore");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Order", b =>
                {
                    b.HasOne("PizzaWorld.Domain.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerEntityID");

                    b.HasOne("PizzaWorld.Domain.Models.Store", "Store")
                        .WithMany("Orders")
                        .HasForeignKey("StoreEntityID");

                    b.Navigation("Customer");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.PrebuiltPizza", b =>
                {
                    b.HasOne("PizzaWorld.Domain.Models.Crust", "Crust")
                        .WithMany()
                        .HasForeignKey("CrustEntityID");

                    b.HasOne("PizzaWorld.Domain.Models.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeEntityID");

                    b.Navigation("Crust");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("PrebuiltPizzaTopping", b =>
                {
                    b.HasOne("PizzaWorld.Domain.Models.PrebuiltPizza", null)
                        .WithMany()
                        .HasForeignKey("PrebuiltPizzasEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaWorld.Domain.Models.Topping", null)
                        .WithMany()
                        .HasForeignKey("ToppingsEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Store", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
