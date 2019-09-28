using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dblab2
{
    public partial class dblab2Context : DbContext
    {
        public dblab2Context()
        {
        }

        public dblab2Context(DbContextOptions<dblab2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientToTour> ClientToTours { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<TravelAgency> TravelAgencies { get; set; }
        public virtual DbSet<TravelAgencyToClient> TravelAgencyToClients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Username=postgres;Password=1111;Database=db-lab1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasColumnType("date");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(32);

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<ClientToTour>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.TourId })
                    .HasName("client_to_tour_pkey");

                entity.ToTable("client_to_tour");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.TourId).HasColumnName("tour_id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientToTour)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("client_to_tour_client_id_fkey");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.ClientToTour)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("client_to_tour_tour_id_fkey");
            });

            modelBuilder.Entity<Tour>(entity =>
            {
                entity.ToTable("tour");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IdTA).HasColumnName("id_t_a");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.Tourdate)
                    .HasColumnName("tourdate")
                    .HasColumnType("date");

                entity.HasOne(d => d.IdTANavigation)
                    .WithMany(p => p.Tour)
                    .HasForeignKey(d => d.IdTA)
                    .HasConstraintName("tour_id_t_a_fkey");
            });

            modelBuilder.Entity<TravelAgency>(entity =>
            {
                entity.ToTable("travel_agency");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnName("adress")
                    .HasMaxLength(64);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<TravelAgencyToClient>(entity =>
            {
                entity.HasKey(e => new { e.TravelAgencyId, e.ClientId })
                    .HasName("travel_agency_to_client_pkey");

                entity.ToTable("travel_agency_to_client");

                entity.Property(e => e.TravelAgencyId).HasColumnName("travel_agency_id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.TravelAgencyToClient)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("travel_agency_to_client_client_id_fkey");

                entity.HasOne(d => d.TravelAgency)
                    .WithMany(p => p.TravelAgencyToClient)
                    .HasForeignKey(d => d.TravelAgencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("travel_agency_to_client_travel_agency_id_fkey");
            });
        }
    }
}
