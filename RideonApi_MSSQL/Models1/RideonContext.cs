using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RideonApi_MSSQL.Models1;

public partial class RideonContext : DbContext
{
    public RideonContext()
    {
    }

    public RideonContext(DbContextOptions<RideonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Medium> Media { get; set; }

    public virtual DbSet<MtbTrack> MtbTracks { get; set; }

    public virtual DbSet<Parking> Parkings { get; set; }

    public virtual DbSet<TrackHead> TrackHeads { get; set; }

    public virtual DbSet<Trackpoint> Trackpoints { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-SH3OF0N; Initial Catalog=Rideon; User Id=Sa; Password=Qwer1234; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Medium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Media__3214EC07A36EDA1F");

            entity.Property(e => e.Link).HasColumnType("text");
            entity.Property(e => e.MtbTrackId).HasColumnName("MTB_TrackId");

            entity.HasOne(d => d.MtbTrack).WithMany(p => p.Media)
                .HasForeignKey(d => d.MtbTrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MTB_TrackId2");
        });

        modelBuilder.Entity<MtbTrack>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MTB_Trac__3214EC079DEB5F0B");

            entity.ToTable("MTB_Track");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasColumnType("text");
            entity.Property(e => e.TrackHeadId).HasColumnName("Track_headId");

            entity.HasOne(d => d.TrackHead).WithMany(p => p.MtbTracks)
                .HasForeignKey(d => d.TrackHeadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Track_HeadId2");
        });

        modelBuilder.Entity<Parking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__parkerin__3214EC074337A79A");

            entity.ToTable("Parking");

            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.City).HasColumnType("text");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Lat).HasColumnType("decimal(8, 6)");
            entity.Property(e => e.Lon).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.TrackHeadId).HasColumnName("Track_headId");

            entity.HasOne(d => d.TrackHead).WithMany(p => p.Parkings)
                .HasForeignKey(d => d.TrackHeadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Track_HeadId");
        });

        modelBuilder.Entity<TrackHead>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Track_he__3214EC0737DA7AA4");

            entity.ToTable("Track_head");

            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.City).HasColumnType("text");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Lat).HasColumnType("decimal(8, 6)");
            entity.Property(e => e.Lon).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Name).HasColumnType("text");
        });

        modelBuilder.Entity<Trackpoint>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Lat).HasColumnType("decimal(8, 6)");
            entity.Property(e => e.Lon).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.MtbTrackId).HasColumnName("MTB_TrackId");

            entity.HasOne(d => d.MtbTrack).WithMany()
                .HasForeignKey(d => d.MtbTrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MTB_TrackId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
