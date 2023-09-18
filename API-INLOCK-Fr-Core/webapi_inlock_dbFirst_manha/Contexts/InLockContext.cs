using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi_inlock_dbFirst_manha.Domains;

namespace webapi_inlock_dbFirst_manha.Contexts;

public partial class InLockContext : DbContext
{
    public InLockContext()
    {
    }

    public InLockContext(DbContextOptions<InLockContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estudio> Estudios { get; set; }

    public virtual DbSet<Jogo> Jogos { get; set; }

    public virtual DbSet<TipoDeUsuario> TipoDeUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=NOTE08-S14; initial catalog=InLock_Games_DBFIRST_Manha; User Id=sa; Pwd=Senai@134; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estudio>(entity =>
        {
            entity.HasKey(e => e.IdEstudio).HasName("PK__Estudio__0C3B4355B4ECEEF3");

            entity.ToTable("Estudio");

            entity.Property(e => e.IdEstudio).ValueGeneratedNever();
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Jogo>(entity =>
        {
            entity.HasKey(e => e.IdJogo).HasName("PK__Jogo__69E085131BF0D36E");

            entity.ToTable("Jogo");

            entity.Property(e => e.IdJogo).ValueGeneratedNever();
            entity.Property(e => e.Datalancamento).HasColumnType("date");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("smallmoney");

            entity.HasOne(d => d.IdEstudioNavigation).WithMany(p => p.Jogos)
                .HasForeignKey(d => d.IdEstudio)
                .HasConstraintName("FK__Jogo__IdEstudio__4BAC3F29");
        });

        modelBuilder.Entity<TipoDeUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoDeUsuario).HasName("PK__TipoDeUs__8C8B582A4EB9BE9B");

            entity.ToTable("TipoDeUsuario");

            entity.Property(e => e.IdTipoDeUsuario).ValueGeneratedNever();
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TItulo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF973FF26ECD");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoDeUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipoDeUsuario)
                .HasConstraintName("FK__Usuario__IdTipoD__534D60F1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

//Comando para conexão com o Banco de dados e criação das Domains e Contexts
//Scaffold-DbContext "Data Source=NOTE08-S14; initial catalog=InLock_Games_DBFIRST_Manha; User Id=sa; Pwd=Senai@134; TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Domains -ContextDir Contexts -Context InLockContext 
