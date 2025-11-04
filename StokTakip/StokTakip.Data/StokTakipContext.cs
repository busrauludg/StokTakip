using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StokTakip.Models;

namespace StokTakip.StokTakip.Data;

public partial class StokTakipContext : DbContext
{
    public StokTakipContext()
    {
    }

    public StokTakipContext(DbContextOptions<StokTakipContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Gruplar> Gruplars { get; set; }

    public virtual DbSet<Personel> Personels { get; set; }

    public virtual DbSet<Proje> Projes { get; set; }

    public virtual DbSet<ProjedeKullanilanUrunler> ProjedeKullanilanUrunlers { get; set; }

    public virtual DbSet<Rapor> Rapors { get; set; }

    public virtual DbSet<SatinAlma> SatinAlmas { get; set; }

    public virtual DbSet<StokDurumu> StokDurumus { get; set; }

    public virtual DbSet<StokHareketi> StokHareketis { get; set; }

    public virtual DbSet<StokKarti> StokKartis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=StokTakipDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gruplar>(entity =>
        {
            entity.HasKey(e => e.GrupId);

            entity.ToTable("Gruplar");

            entity.Property(e => e.GrupAdi).HasMaxLength(100);
        });

        modelBuilder.Entity<Personel>(entity =>
        {
            entity.ToTable("Personel");

            entity.Property(e => e.Ad).HasMaxLength(50);
            entity.Property(e => e.Eposta).HasMaxLength(100);
            entity.Property(e => e.Gorev).HasMaxLength(100);
            entity.Property(e => e.KayitTarihi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Sifre).HasMaxLength(100);
            entity.Property(e => e.Soyad).HasMaxLength(50);
            entity.Property(e => e.Telefon).HasMaxLength(20);
            entity.Property(e => e.Rol).HasDefaultValue(false);//eğer kullanıcı rolü belirtmezse otomatik olarak false yani “Personel” olacak şekilde ayarlanıyor.
            entity.Property(e => e.YetkiliSifre).HasMaxLength(100);
            // 🔹 Sadece Personel için
            entity.HasQueryFilter(p => p.Aktif);
        });

        modelBuilder.Entity<Proje>(entity =>
        {
            entity.ToTable("Proje");

            entity.Property(e => e.Aciklama).HasMaxLength(250);
            entity.Property(e => e.BaslangicTarihi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.BitisTarihi).HasColumnType("datetime");
            entity.Property(e => e.ProjeAdi).HasMaxLength(100);

            entity.HasOne(d => d.Personel).WithMany(p => p.Projes)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proje_Personel");
        });

        modelBuilder.Entity<ProjedeKullanilanUrunler>(entity =>
        {
            entity.HasKey(e => e.KullanilanUrunId);

            entity.ToTable("ProjedeKullanilanUrunler");

            entity.Property(e => e.Maliyet).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Proje).WithMany(p => p.ProjedeKullanilanUrunlers)
                .HasForeignKey(d => d.ProjeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjedeKullanilanUrunler_Proje");

            entity.HasOne(d => d.StokKarti).WithMany(p => p.ProjedeKullanilanUrunlers)
                .HasForeignKey(d => d.StokKartiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjedeKullanilanUrunler_StokKarti");
        });

        modelBuilder.Entity<Rapor>(entity =>
        {
            entity.ToTable("Rapor");

            entity.Property(e => e.RaporId).ValueGeneratedOnAdd();
            entity.Property(e => e.BaslangicTarihi).HasColumnType("datetime");
            entity.Property(e => e.BitisTarihi).HasColumnType("datetime");
            entity.Property(e => e.GelenTutar).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HarcananTutar).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.KullanilanMaliyet).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProjeAciklama).HasMaxLength(250);

            entity.HasOne(d => d.RaporNavigation).WithOne(p => p.Rapor)
                .HasForeignKey<Rapor>(d => d.RaporId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rapor_Proje");
        });

        modelBuilder.Entity<SatinAlma>(entity =>
        {
            entity.HasKey(e => e.SiparisId).HasName("PK__SatinAlm__C3F03BFDE33C702A");

            entity.ToTable("SatinAlma");

            entity.Property(e => e.BirimFiyat).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.CariAdi).HasMaxLength(100);
            entity.Property(e => e.Kur).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.ParaBirimi).HasMaxLength(10);
            entity.Property(e => e.SiparisTarihi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Personel).WithMany(p => p.SatinAlmas)
                .HasForeignKey(d => d.PersonelId)
                .HasConstraintName("FK_SatinAlma_Personel");

            entity.HasOne(d => d.StokKarti).WithMany(p => p.SatinAlmas)
                .HasForeignKey(d => d.StokKartiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SatinAlma_StokKarti");
        });

        modelBuilder.Entity<StokDurumu>(entity =>
        {
            entity.HasKey(e => e.DurumId);

            entity.ToTable("StokDurumu");

            entity.Property(e => e.BlokeMiktar)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.DepoAdi).HasMaxLength(50);

            entity.HasOne(d => d.StokKarti).WithMany(p => p.StokDurumus)
                .HasForeignKey(d => d.StokKartiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StokDurumu_StokKarti");
        });

        modelBuilder.Entity<StokHareketi>(entity =>
        {
            entity.HasKey(e => e.HareketId);

            entity.ToTable("StokHareketi");

            entity.Property(e => e.Aciklama).HasMaxLength(250);
            entity.Property(e => e.Tarih)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Tip).HasMaxLength(10);

            entity.HasOne(d => d.Personel).WithMany(p => p.StokHareketis)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StokHareketi_Personel");

            entity.HasOne(d => d.StokKarti).WithMany(p => p.StokHareketis)
                .HasForeignKey(d => d.StokKartiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StokHareketi_StokKarti");
        });

        modelBuilder.Entity<StokKarti>(entity =>
        {
            entity.HasKey(e => e.StokKartiId).HasName("PK_StokKartı");

            entity.ToTable("StokKarti");

            entity.Property(e => e.Aciklama).HasMaxLength(250);
            entity.Property(e => e.DepoAdresi).HasMaxLength(150);
            entity.Property(e => e.FirmaAdi).HasMaxLength(100);
            entity.Property(e => e.FirmaKodu).HasMaxLength(50);
            entity.Property(e => e.KayitTarihi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ResimYolu).HasMaxLength(250);
            entity.Property(e => e.StokBirimi).HasMaxLength(20);
            entity.Property(e => e.StokKodu).HasMaxLength(50);
            entity.Property(e => e.UrunAdi).HasMaxLength(100);

            // 🔹 Buraya ekle
     
            entity.HasOne(d => d.Grup).WithMany(p => p.StokKartis)
                .HasForeignKey(d => d.GrupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StokKarti_Gruplar");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
