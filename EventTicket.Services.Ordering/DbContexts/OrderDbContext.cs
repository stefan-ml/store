using EventTicket.Services.Ordering.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EventTicket.Services.Ordering.DbContexts
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

    }
}