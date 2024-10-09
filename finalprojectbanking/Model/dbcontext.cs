﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using finalprojectbanking.Model;


namespace finalprojectbanking.Model
{
    public class dbcontext:DbContext
    {
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\Thest\source\repos\bankingcs\finalprojectbankingDB.db");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<AdminRegister> AdminRegisters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MoneyTrans> MoneyTranss { get; set; }
        public DbSet<OrdLone> OrdLones { get; set; }
        public DbSet<EditOraLone> EditOraLones { get; set; }
        public DbSet<Emer> Emers { get; set; }
        public DbSet<UserPayment> UserPayments { get; set; }
        public DbSet<UserExit> UserExits { get; set; }
       
    }
}
