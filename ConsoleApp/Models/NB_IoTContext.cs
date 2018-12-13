using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleApp.Models
{
    public partial class NbIoTContext : DbContext
    {
        public NbIoTContext()
        {
        }

        public NbIoTContext(DbContextOptions<NbIoTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlarmLog> AlarmLog { get; set; }
        public virtual DbSet<ApplicationRoleRoleTemplets> ApplicationRoleRoleTemplets { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<CommandLog> CommandLog { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<DeviceDataLog> DeviceDataLog { get; set; }
        public virtual DbSet<DeviceModel> DeviceModel { get; set; }
        public virtual DbSet<Entity> Entity { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<RoleTemplet> RoleTemplet { get; set; }
        public virtual DbSet<RoleTempletApplicationUsers> RoleTempletApplicationUsers { get; set; }
        public virtual DbSet<Rule> Rule { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=NB_IoT;Trusted_Connection=True;");//"Server=Aron1;Database=pubs;Uid=sa;Pwd=asdasd;"
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<AlarmLog>(entity =>
            {
                entity.HasIndex(e => e.EntityId)
                    .HasName("IX_Entity_Id");

                entity.HasIndex(e => new { e.Id, e.IsDisable, e.Reasons, e.Conditions, e.ActionName, e.Description, e.RecoveryAction, e.EntityId, e.AlarmStatus, e.Severity, e.RecoveryReason, e.RuleId, e.CreateTime, e.RecoveryTime })
                    .HasName("IX_AlarmLog_Entity_Id_AlarmStatus_Severity_RecoveryReason_ruleId_CreateTime_RecoveryTime");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ActionName).HasColumnType("nvarchar(max)");

                entity.Property(e => e.Conditions).HasColumnType("nvarchar(max)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("nvarchar(max)");

                entity.Property(e => e.EntityId).HasColumnName("Entity_Id");

                entity.Property(e => e.Reasons).HasColumnType("nvarchar(max)");

                entity.Property(e => e.RecoveryAction).HasColumnType("nvarchar(max)");

                entity.Property(e => e.RecoveryTime).HasColumnType("datetime");

                entity.Property(e => e.RuleId)
                    .HasColumnName("ruleId")
                    .HasMaxLength(64);

                entity.HasOne(d => d.Entity)
                    .WithMany(p => p.AlarmLog)
                    .HasForeignKey(d => d.EntityId)
                    .HasConstraintName("FK_dbo.AlarmLog_dbo.Entity_Entity_Id");
            });

            modelBuilder.Entity<ApplicationRoleRoleTemplets>(entity =>
            {
                entity.HasKey(e => new { e.ApplicationRoleId, e.RoleTempletId })
                    .HasName("PK_dbo.ApplicationRoleRoleTemplets");

                entity.HasIndex(e => e.ApplicationRoleId)
                    .HasName("IX_ApplicationRole_Id");

                entity.HasIndex(e => e.RoleTempletId)
                    .HasName("IX_RoleTemplet_Id");

                entity.Property(e => e.ApplicationRoleId)
                    .HasColumnName("ApplicationRole_Id")
                    .HasMaxLength(128);

                entity.Property(e => e.RoleTempletId).HasColumnName("RoleTemplet_Id");

                entity.HasOne(d => d.ApplicationRole)
                    .WithMany(p => p.ApplicationRoleRoleTemplets)
                    .HasForeignKey(d => d.ApplicationRoleId)
                    .HasConstraintName("FK_dbo.ApplicationRoleRoleTemplets_dbo.AspNetRoles_ApplicationRole_Id");

                entity.HasOne(d => d.RoleTemplet)
                    .WithMany(p => p.ApplicationRoleRoleTemplets)
                    .HasForeignKey(d => d.RoleTempletId)
                    .HasConstraintName("FK_dbo.ApplicationRoleRoleTemplets_dbo.RoleTemplet_RoleTemplet_Id");
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.EntityId)
                    .HasName("IX_Entity_Id");

                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.EntityId).HasColumnName("Entity_Id");

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Entity)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.EntityId)
                    .HasConstraintName("FK_dbo.AspNetUsers_dbo.Entity_Entity_Id");
            });

            modelBuilder.Entity<CommandLog>(entity =>
            {
                entity.HasIndex(e => new { e.Id, e.IsDisable, e.Command, e.CallbackUrl, e.ExpireTime, e.MaxRetransmit, e.AppId, e.CreateTime, e.DeviceId, e.Status, e.DeliveredTime })
                    .HasName("IX_CommandLog_appId_CreateTime_deviceId_status_deliveredTime");

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.AppId)
                    .HasColumnName("appId")
                    .HasMaxLength(30);

                entity.Property(e => e.CallbackUrl)
                    .HasColumnName("callbackUrl")
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Command)
                    .HasColumnName("command")
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeliveredTime)
                    .HasColumnName("deliveredTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceId).HasColumnName("deviceId");

                entity.Property(e => e.ExpireTime).HasColumnName("expireTime");

                entity.Property(e => e.MaxRetransmit).HasColumnName("maxRetransmit");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasIndex(e => e.DeviceModelId)
                    .HasName("IX_DeviceModel_Id");

                entity.HasIndex(e => e.EntityId)
                    .HasName("IX_Entity_Id");

                entity.HasIndex(e => new { e.Id, e.EndUserId, e.Timeout, e.Location, e.Photo, e.EntityId, e.CreateTime, e.NodeId, e.IsSecure, e.DeviceModelId, e.IsDisable, e.DevGroup, e.DevGroupId, e.Psk })
                    .HasName("IX_Device_Entity_Id_CreateTime_nodeId_isSecure_DeviceModel_Id_IsDisable_devGroup_devGroupId_psk");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DevGroup)
                    .HasColumnName("devGroup")
                    .HasMaxLength(64);

                entity.Property(e => e.DevGroupId)
                    .HasColumnName("devGroupId")
                    .HasMaxLength(40);

                entity.Property(e => e.DeviceModelId).HasColumnName("DeviceModel_Id");

                entity.Property(e => e.EndUserId)
                    .HasColumnName("endUserId")
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.EntityId).HasColumnName("Entity_Id");

                entity.Property(e => e.IsSecure).HasColumnName("isSecure");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(32);

                entity.Property(e => e.NodeId)
                    .HasColumnName("nodeId")
                    .HasMaxLength(80);

                entity.Property(e => e.Photo).HasColumnType("nvarchar(max)");

                entity.Property(e => e.Psk)
                    .HasColumnName("psk")
                    .HasMaxLength(40);

                entity.Property(e => e.Timeout).HasColumnName("timeout");

                entity.HasOne(d => d.DeviceModel)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.DeviceModelId)
                    .HasConstraintName("FK_dbo.Device_dbo.DeviceModel_DeviceModel_Id");

                entity.HasOne(d => d.Entity)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.EntityId)
                    .HasConstraintName("FK_dbo.Device_dbo.Entity_Entity_Id");
            });

            modelBuilder.Entity<DeviceDataLog>(entity =>
            {
                entity.HasIndex(e => new { e.Id, e.IsDisable, e.CreateTime, e.Data, e.DeviceId, e.ServiceId, e.ServiceType })
                    .HasName("IX_DeviceDataLog_deviceId_serviceId_serviceType");

                entity.HasIndex(e => new { e.Id, e.IsDisable, e.Data, e.CreateTime, e.DeviceId, e.ServiceId, e.ServiceType })
                    .HasName("IX_DeviceDataLog_CreateTime_deviceId_serviceId_serviceType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.DeviceId)
                    .HasColumnName("deviceId")
                    .HasMaxLength(40);

                entity.Property(e => e.ServiceId)
                    .HasColumnName("serviceId")
                    .HasMaxLength(36);

                entity.Property(e => e.ServiceType)
                    .HasColumnName("serviceType")
                    .HasMaxLength(36);
            });

            modelBuilder.Entity<DeviceModel>(entity =>
            {
                entity.HasIndex(e => new { e.Id, e.Photo, e.AppId, e.DeviceType, e.ManufacturerName, e.ManufacturerId, e.Model, e.IsDisable, e.ProtocolType, e.CreateTime })
                    .HasName("IX_DeviceModel_appId_deviceType_manufacturerName_manufacturerId_model_IsDisable_protocolType_CreateTime");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AppId)
                    .HasColumnName("appId")
                    .HasMaxLength(64);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeviceType)
                    .HasColumnName("deviceType")
                    .HasMaxLength(64);

                entity.Property(e => e.ManufacturerId)
                    .HasColumnName("manufacturerId")
                    .HasMaxLength(64);

                entity.Property(e => e.ManufacturerName)
                    .HasColumnName("manufacturerName")
                    .HasMaxLength(64);

                entity.Property(e => e.Model)
                    .HasColumnName("model")
                    .HasMaxLength(64);

                entity.Property(e => e.Photo).HasColumnType("nvarchar(max)");

                entity.Property(e => e.ProtocolType)
                    .HasColumnName("protocolType")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Entity>(entity =>
            {
                entity.HasIndex(e => new { e.Id, e.SystemName, e.Company, e.Secret, e.AppId, e.CreateTime, e.IsDisable })
                    .HasName("IX_Entity_appId_CreateTime_IsDisable");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AppId).HasMaxLength(64);

                entity.Property(e => e.Company).HasColumnType("nvarchar(max)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Secret).HasMaxLength(32);

                entity.Property(e => e.SystemName).HasColumnType("nvarchar(max)");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<RoleTemplet>(entity =>
            {
                entity.HasIndex(e => e.EntityId)
                    .HasName("IX_Entity_Id");

                entity.HasIndex(e => new { e.Id, e.IsDisable, e.CreateTime, e.Name, e.EntityId })
                    .HasName("IX_RoleTemplet_Entity_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.EntityId).HasColumnName("Entity_Id");

                entity.Property(e => e.Name).HasColumnType("nvarchar(max)");

                entity.HasOne(d => d.Entity)
                    .WithMany(p => p.RoleTemplet)
                    .HasForeignKey(d => d.EntityId)
                    .HasConstraintName("FK_dbo.RoleTemplet_dbo.Entity_Entity_Id");
            });

            modelBuilder.Entity<RoleTempletApplicationUsers>(entity =>
            {
                entity.HasKey(e => new { e.RoleTempletId, e.ApplicationUserId })
                    .HasName("PK_dbo.RoleTempletApplicationUsers");

                entity.HasIndex(e => e.ApplicationUserId)
                    .HasName("IX_ApplicationUser_Id");

                entity.HasIndex(e => e.RoleTempletId)
                    .HasName("IX_RoleTemplet_Id");

                entity.Property(e => e.RoleTempletId).HasColumnName("RoleTemplet_Id");

                entity.Property(e => e.ApplicationUserId)
                    .HasColumnName("ApplicationUser_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.RoleTempletApplicationUsers)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .HasConstraintName("FK_dbo.RoleTempletApplicationUsers_dbo.AspNetUsers_ApplicationUser_Id");

                entity.HasOne(d => d.RoleTemplet)
                    .WithMany(p => p.RoleTempletApplicationUsers)
                    .HasForeignKey(d => d.RoleTempletId)
                    .HasConstraintName("FK_dbo.RoleTempletApplicationUsers_dbo.RoleTemplet_RoleTemplet_Id");
            });

            modelBuilder.Entity<Rule>(entity =>
            {
                entity.HasIndex(e => new { e.Id, e.IsDisable, e.Name, e.Description, e.AppKey, e.CreateTime, e.Status, e.Author })
                    .HasName("IX_Rule_appKey_CreateTime_status_author");

                entity.HasIndex(e => new { e.Id, e.IsDisable, e.Name, e.Description, e.CreateTime, e.AppKey, e.Status, e.Author })
                    .HasName("IX_Rule_CreateTime_appKey_status_author");

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.AppKey)
                    .HasColumnName("appKey")
                    .HasMaxLength(64);

                entity.Property(e => e.Author)
                    .HasColumnName("author")
                    .HasMaxLength(30);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(10);
            });
        }
    }
}
