using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PastryShopApi.ModelPastryShop
{
    public partial class PastryShopContext : DbContext
    {
        public PastryShopContext()
        {
        }

        public PastryShopContext(DbContextOptions<PastryShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dolce> Dolces { get; set; }
        public virtual DbSet<DolciInVenditum> DolciInVendita { get; set; }
        public virtual DbSet<Ingrediente> Ingredientes { get; set; }
        public virtual DbSet<IngredientiDolce> IngredientiDolces { get; set; }
        public virtual DbSet<Um> Ums { get; set; }
        public virtual DbSet<Utente> Utentes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PastryShop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Dolce>(entity =>
            {
                entity.ToTable("Dolce");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Prezzo).HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<DolciInVenditum>(entity =>
            {
                entity.Property(e => e.DataMessaInVendita).HasColumnType("datetime");

                entity.Property(e => e.Scaduto).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdDolceNavigation)
                    .WithMany(p => p.DolciInVendita)
                    .HasForeignKey(d => d.IdDolce)
                    .HasConstraintName("FK_DolciInVendita_Dolce");
            });

            modelBuilder.Entity<Ingrediente>(entity =>
            {
                entity.ToTable("Ingrediente");

                entity.Property(e => e.Nome).HasMaxLength(50);

                entity.HasOne(d => d.UmNavigation)
                    .WithMany(p => p.Ingredientes)
                    .HasForeignKey(d => d.Um)
                    .HasConstraintName("FK_Ingrediente_Um");
            });

            modelBuilder.Entity<IngredientiDolce>(entity =>
            {
                entity.ToTable("IngredientiDolce");

                entity.Property(e => e.Quantita).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdDolceNavigation)
                    .WithMany(p => p.IngredientiDolces)
                    .HasForeignKey(d => d.IdDolce)
                    .HasConstraintName("FK_IngredientiDolce_Dolce");

                entity.HasOne(d => d.IdIngredienteNavigation)
                    .WithMany(p => p.IngredientiDolces)
                    .HasForeignKey(d => d.IdIngrediente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IngredientiDolce_Ingrediente");
            });

            modelBuilder.Entity<Um>(entity =>
            {
                entity.ToTable("Um");

                entity.Property(e => e.NomeCompleto).HasMaxLength(30);

                entity.Property(e => e.Sigla).HasMaxLength(5);
            });

            modelBuilder.Entity<Utente>(entity =>
            {
                entity.ToTable("Utente");

                entity.Property(e => e.Nome).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
