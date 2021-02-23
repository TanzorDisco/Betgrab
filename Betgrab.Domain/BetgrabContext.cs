using Betgrab.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Betgrab.Domain
{
	public class BetgrabContext : DbContext
	{
		private readonly IConfiguration _config;

		public DbSet<Club> Clubs { get; set; }
		public DbSet<ClubMember> ClubMember { get; set; }
		public DbSet<ClubLeague> ClubLeague { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<EventStats> EventStats { get; set; }
		public DbSet<Fact> Facts { get; set; }
		public DbSet<League> Leagues { get; set; }
		public DbSet<Nation> Nations { get; set; }
		public DbSet<Player> Players { get; set; }
		public DbSet<Stage> Stages { get; set; }

		public BetgrabContext(IConfiguration config)
		{
			_config = config;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			var conStr = _config.GetConnectionString("NpgsqlBetgrab");

			optionsBuilder
				.UseNpgsql(conStr);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Club>().Property(e => e.Name).HasColumnType("varchar(2000)");

			modelBuilder.Entity<Event>().HasOne(e => e.Club1).WithMany().HasForeignKey(e => e.Club1Id).OnDelete(DeleteBehavior.Restrict);
			modelBuilder.Entity<Event>().HasOne(e => e.Club2).WithMany().HasForeignKey(e => e.Club2Id).OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Club>()
				.ToTable("Clubs")
				.HasIndex(e => e.LivescoreId)
				.IsUnique();
			modelBuilder.Entity<ClubMember>().ToTable("ClubMember");
			modelBuilder.Entity<ClubLeague>().ToTable("ClubLeague");
			modelBuilder.Entity<Event>()
				.ToTable("Events")
				.HasIndex(e => e.LivescoreId)
				.IsUnique();
			modelBuilder.Entity<EventStats>()
				.ToTable("EventStats");
			modelBuilder.Entity<Fact>()
				.ToTable("Facts")
				.HasIndex(e => e.LivescoreId)
				.IsUnique();
			modelBuilder.Entity<League>()
				.ToTable("Leagues")
				.HasIndex(e => e.LivescoreId)
				.IsUnique();
			modelBuilder.Entity<Nation>()
				.ToTable("Nations")
				.HasIndex(e => e.LivescoreId)
				.IsUnique();
			modelBuilder.Entity<Player>()
				.ToTable("Players")
				.HasIndex(e => e.LivescoreId)
				.IsUnique();
			modelBuilder.Entity<Stage>()
				.ToTable("Stages")
				.HasIndex(e => e.LivescoreId)
				.IsUnique();
		}
	}
}
