﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using finalprojectbanking.Model;

#nullable disable

namespace finalprojectbanking.Migrations
{
    [DbContext(typeof(dbcontext))]
    [Migration("20240817131513_Emer")]
    partial class Emer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("finalprojectbanking.Model.AdminRegister", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Idcard")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AdminRegisters");
                });

            modelBuilder.Entity("finalprojectbanking.Model.EditOraLone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EditUsername1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EditUsername2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EditUsername3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Fullname1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Fullname2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Fullname3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IdCard")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("LoneMoney")
                        .HasColumnType("REAL");

                    b.Property<double>("LoneMoney1")
                        .HasColumnType("REAL");

                    b.Property<double>("MoneyOld")
                        .HasColumnType("REAL");

                    b.Property<string>("NumberLone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("TotalMoneyLone")
                        .HasColumnType("REAL");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EditOraLones");
                });

            modelBuilder.Entity("finalprojectbanking.Model.Emer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Fullname1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Fullname2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Fullname3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IdCard")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("LoneMoney")
                        .HasColumnType("REAL");

                    b.Property<double>("MoneyOld")
                        .HasColumnType("REAL");

                    b.Property<string>("NumberLone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeLone")
                        .HasColumnType("TEXT");

                    b.Property<double>("TotalMoneyLone")
                        .HasColumnType("REAL");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Emers");
                });

            modelBuilder.Entity("finalprojectbanking.Model.MoneyTrans", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IdCard")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("MoneyLast")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("MoneyOld")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("MoneyTotal")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeMoney")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MoneyTranss");
                });

            modelBuilder.Entity("finalprojectbanking.Model.OrdLone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Fullname1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Fullname2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Fullname3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IdCard")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("LoneMoney")
                        .HasColumnType("REAL");

                    b.Property<double>("LoneMoney1")
                        .HasColumnType("REAL");

                    b.Property<double>("MoneyOld")
                        .HasColumnType("REAL");

                    b.Property<string>("NumberLone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeLone")
                        .HasColumnType("TEXT");

                    b.Property<double>("TotalMoneyLone")
                        .HasColumnType("REAL");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("OrdLones");
                });

            modelBuilder.Entity("finalprojectbanking.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IdCard")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneUser1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneUser2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("User1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("User2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
