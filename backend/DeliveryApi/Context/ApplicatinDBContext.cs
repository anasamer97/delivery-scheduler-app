using CallCenterAPI.Classes;
using Microsoft.EntityFrameworkCore;
using System;

namespace CallCenterAPI.Context
{
	public class ApplicatinDBContext:DbContext
	{
		public ApplicatinDBContext(DbContextOptions<ApplicatinDBContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>().HasOne(p => p.Order).WithMany(o => o.Products).HasForeignKey(p => p.OrdertId);
		}

		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }
	}
}
