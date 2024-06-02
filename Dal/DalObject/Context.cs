using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.DalObject;

public partial class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Profession> Professions { get; set; }

    public virtual DbSet<ProfessionalsMan> ProfessionalsMen { get; set; }

    public virtual DbSet<Reference> References { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Address__3214EC07C19EEA8E");

            entity.ToTable("Address");

            entity.Property(e => e.Building).HasColumnName("building");
            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("city");
            entity.Property(e => e.Neighborhood)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("neighborhood");
            entity.Property(e => e.Street)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("street");
        });

        modelBuilder.Entity<Profession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__professi__3214EC072B04D3D5");

            entity.ToTable("profession");

            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("type");
        });

        modelBuilder.Entity<ProfessionalsMan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Professi__3214EC0798ABE15A");

            entity.ToTable("ProfessionalsMan");

            entity.Property(e => e.Email)
                .HasMaxLength(35)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("first_name");
            entity.Property(e => e.IdAdress).HasColumnName("id_adress");
            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.LastName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("last_name");
            entity.Property(e => e.Phon)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("phon");
            entity.Property(e => e.WhatsApp)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("whatsApp");

            entity.HasOne(d => d.IdAdressNavigation).WithMany(p => p.ProfessionalsMen)
                .HasForeignKey(d => d.IdAdress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProfessionalsMan_ToTable");

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.ProfessionalsMen)
                .HasForeignKey(d => d.IdType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProfessionalsMan_ToTableProfession");
        });

        modelBuilder.Entity<Reference>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__referenc__3214EC07EF025432");

            entity.ToTable("references");

            entity.Property(e => e.Describe)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("describe");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(25)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.IdProfessionals).HasColumnName("id_Professionals");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Phon)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("phon");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.IdProfessionalsNavigation).WithMany(p => p.References)
                .HasForeignKey(d => d.IdProfessionals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_reference_ToTable");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
