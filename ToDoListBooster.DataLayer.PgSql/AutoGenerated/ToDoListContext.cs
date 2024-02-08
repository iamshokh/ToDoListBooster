using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ToDoListBooster.DataLayer.PgSql
{
    public partial class ToDoListContext : DbContext
    {
        public ToDoListContext()
        {
        }

        public ToDoListContext(DbContextOptions<ToDoListContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DocTaskItem> DocTaskItems { get; set; } = null!;
        public virtual DbSet<DocTaskList> DocTaskLists { get; set; } = null!;
        public virtual DbSet<EnumStatus> EnumStatuses { get; set; } = null!;
        public virtual DbSet<InfoComment> InfoComments { get; set; } = null!;
        public virtual DbSet<SysUser> SysUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=shaxzod71319#;Database=ToDoList");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocTaskItem>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.DocTaskItems)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_status_id");

                entity.HasOne(d => d.TaskList)
                    .WithMany(p => p.DocTaskItems)
                    .HasForeignKey(d => d.TaskListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_task_list_id");
            });

            modelBuilder.Entity<DocTaskList>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("now()");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DocTaskLists)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_id");
            });

            modelBuilder.Entity<EnumStatus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<InfoComment>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("now()");

                entity.HasOne(d => d.TaskItem)
                    .WithMany(p => p.InfoComments)
                    .HasForeignKey(d => d.TaskItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_task_item_id");
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("now()");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
