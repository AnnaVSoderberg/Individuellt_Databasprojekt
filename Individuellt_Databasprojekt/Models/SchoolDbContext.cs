using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Individuellt_Databasprojekt.Models
{
    public partial class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
        {
        }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<KpersonalHarKur> KpersonalHarKurs { get; set; } = null!;
        public virtual DbSet<KsattaBetyg> KsattaBetygs { get; set; } = null!;
        public virtual DbSet<KstudenterIkurser> KstudenterIkursers { get; set; } = null!;
        public virtual DbSet<TblBetyg> TblBetygs { get; set; } = null!;
        public virtual DbSet<TblKlasser> TblKlassers { get; set; } = null!;
        public virtual DbSet<TblKur> TblKurs { get; set; } = null!;
        public virtual DbSet<TblPersonal> TblPersonals { get; set; } = null!;
        public virtual DbSet<TblStudent> TblStudents { get; set; } = null!;
        public virtual DbSet<TblTitlar> TblTitlars { get; set; } = null!;
        public virtual DbSet<VWspersonalTitel> VWspersonalTitels { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source = DESKTOP-LNIG6K5;Initial Catalog = School;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KpersonalHarKur>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("KPersonalHarKurs");

                entity.Property(e => e.KurskodNy).HasColumnName("KurskodNY");

                entity.Property(e => e.PersonalId).HasColumnName("PersonalID");

                entity.HasOne(d => d.KurskodNyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.KurskodNy)
                    .HasConstraintName("FK_KPersonalHarKurs_tblKurs");

                entity.HasOne(d => d.Personal)
                    .WithMany()
                    .HasForeignKey(d => d.PersonalId)
                    .HasConstraintName("FK_KPersonalHarKurs_tblPersonal");
            });

            modelBuilder.Entity<KsattaBetyg>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("KSattaBetyg");

                entity.Property(e => e.BetygId).HasColumnName("BetygID");

                entity.Property(e => e.Betygsdatum).HasColumnType("date");

                entity.Property(e => e.KurskodNy).HasColumnName("kurskodNY");

                entity.Property(e => e.PersonalId).HasColumnName("personalID");

                entity.HasOne(d => d.Betyg)
                    .WithMany()
                    .HasForeignKey(d => d.BetygId)
                    .HasConstraintName("FK_KSattaBetyg_tblBetyg");

                entity.HasOne(d => d.KurskodNyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.KurskodNy)
                    .HasConstraintName("FK_KSattaBetyg_tblKurs");

                entity.HasOne(d => d.Personal)
                    .WithMany()
                    .HasForeignKey(d => d.PersonalId)
                    .HasConstraintName("FK_KSattaBetyg_tblPersonal");

                entity.HasOne(d => d.Student)
                    .WithMany()
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_KSattaBetyg_tblStudent");
            });

            modelBuilder.Entity<KstudenterIkurser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("KStudenterIKurser");

                entity.Property(e => e.KurskodNy).HasColumnName("kurskodNY");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.KurskodNyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.KurskodNy)
                    .HasConstraintName("FK_KStudenterIKurser_tblKurs");

                entity.HasOne(d => d.Student)
                    .WithMany()
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_KStudenterIKurser_tblStudent1");
            });

            modelBuilder.Entity<TblBetyg>(entity =>
            {
                entity.HasKey(e => e.BetygId)
                    .HasName("PK__tblBetyg__E90ED0485A35972D");

                entity.ToTable("tblBetyg");

                entity.Property(e => e.BetygId).HasColumnName("BetygID");

                entity.Property(e => e.Betyg)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblKlasser>(entity =>
            {
                entity.HasKey(e => e.KlassId)
                    .HasName("PK__Klasser__CF47A60D33E6B237");

                entity.ToTable("tblKlasser");

                entity.Property(e => e.KlassId).HasColumnName("KlassID");

                entity.Property(e => e.KlassNamn)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblKur>(entity =>
            {
                entity.HasKey(e => e.KurskodNy);

                entity.ToTable("tblKurs");

                entity.Property(e => e.KurskodNy).HasColumnName("kurskodNy");

                entity.Property(e => e.Kursnamn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Kursslut)
                    .HasColumnType("date")
                    .HasColumnName("kursslut");

                entity.Property(e => e.Kursstart).HasColumnType("date");
            });

            modelBuilder.Entity<TblPersonal>(entity =>
            {
                entity.HasKey(e => e.PersonalId)
                    .HasName("PK__tblPerso__28343713BC340614");

                entity.ToTable("tblPersonal");

                entity.Property(e => e.PersonalId).HasColumnName("PersonalID");

                entity.Property(e => e.Efternamn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Förnamn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lön).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StartDatum).HasColumnType("date");

                entity.HasOne(d => d.TitelNavigation)
                    .WithMany(p => p.TblPersonals)
                    .HasForeignKey(d => d.Titel)
                    .HasConstraintName("FK_tblPersonal_Titlar");
            });

            modelBuilder.Entity<TblStudent>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.ToTable("tblStudent");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.Efternamn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Förnamn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Personnummer)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.KlassNavigation)
                    .WithMany(p => p.TblStudents)
                    .HasForeignKey(d => d.Klass)
                    .HasConstraintName("FK_tblStudent_tblKlasser");
            });

            modelBuilder.Entity<TblTitlar>(entity =>
            {
                entity.HasKey(e => e.TitelId)
                    .HasName("PK__Titlar__6E58D659325B3EA8");

                entity.ToTable("tblTitlar");

                entity.Property(e => e.TitelId).HasColumnName("TitelID");

                entity.Property(e => e.Titel)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VWspersonalTitel>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWSPersonalTitel");

                entity.Property(e => e.Efternamn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Förnamn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PersonalId).HasColumnName("personalID");

                entity.Property(e => e.Titel)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
