using System;
using System.Collections.Generic;
using ConferencesDomain.Model;
using Microsoft.EntityFrameworkCore;

//namespace ConferencesDomain.Model;
namespace ConferencesInfrastructure;

public partial class DbconferencesContext : DbContext
{
    public DbconferencesContext()
    {
    }

    public DbconferencesContext(DbContextOptions<DbconferencesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Conference> Conferences { get; set; }

    public virtual DbSet<Organizer> Organizers { get; set; }

    public virtual DbSet<SignUp> SignUps { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-B8OBOTM\\SQLEXPRESS; Database=DBConferences; Trusted_Connection=True; TrustServerCertificate=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conference>(entity =>
        {
            entity.ToTable("Conference");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.DateTime).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Orgaizer).WithMany(p => p.Conferences)
                .HasForeignKey(d => d.OrgaizerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Conference_Organizer");

            entity.HasOne(d => d.Topic).WithMany(p => p.Conferences)
                .HasForeignKey(d => d.TopicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Conference_Topic");
        });

        modelBuilder.Entity<Organizer>(entity =>
        {
            entity.ToTable("Organizer");

            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Login)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<SignUp>(entity =>
        {
            entity.ToTable("SignUp");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ConferenseId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Conferense).WithMany(p => p.SignUps)
                .HasForeignKey(d => d.ConferenseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SignUp_Conference");

            entity.HasOne(d => d.User).WithMany(p => p.SignUps)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SignUp_User");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.ToTable("Topic");

            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Login)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
