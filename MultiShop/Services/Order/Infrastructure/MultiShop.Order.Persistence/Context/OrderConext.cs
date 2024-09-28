﻿using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistence.Context
{
    public class OrderConext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-75LJ1CC\\SQLEXPRESS;initial Catalog=MultiShopOrderDb;Integrated Security=True");
        }

        public DbSet<Address> Addresses { get; set; } 
        public DbSet<OrderDetail> OrderDetails { get; set; } 
        public DbSet<Ordering> Orderings { get; set; } 
    }
}