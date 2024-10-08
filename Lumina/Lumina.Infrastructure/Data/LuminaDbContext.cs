﻿using Lumina.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lumina.Infrastructure.Data
{
	public class LuminaDbContext : IdentityDbContext<AppUser>
	{
		public DbSet<Profile> Profiles { get; set; }

		public LuminaDbContext()
		{

		}

		public LuminaDbContext(DbContextOptions<LuminaDbContext> options) : base(options)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("server=.;database=LuminaDb;Trusted_Connection=true;TrustServerCertificate=True");
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// Configure the one-to-one relationship
			builder.Entity<AppUser>()
				.HasOne(a => a.Profile)
				.WithOne(b => b.AppUser)
				.HasForeignKey<Profile>(b => b.AppUserId);

			// Configure the self-referencing relationships for CreatedBy and ModifiedBy
			builder.Entity<AppUser>()
				.HasOne(a => a.Creator)
				.WithMany()
				.HasForeignKey(a => a.CreatedBy)
				.OnDelete(DeleteBehavior.Restrict); // Optional: Prevent cascading deletes

			builder.Entity<AppUser>()
				.HasOne(a => a.Modifier)
				.WithMany()
				.HasForeignKey(a => a.ModifiedBy)
				.OnDelete(DeleteBehavior.Restrict); // Optional: Prevent cascading deletes
		}

	}
}
