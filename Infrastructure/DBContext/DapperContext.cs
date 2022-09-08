using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using Domains.Entities;


namespace Infrastructure.DBContext
{
    public partial class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DBConnection");
        }

        public IDbConnection CreateConnection()
            => new NpgsqlConnection(_connectionString);


        //public DapperContext(DbContextOptions<DapperContext> options) : base(options)
        //{

        //}

        //public virtual DbSet<Users> Users { get; set; }



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //    }
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

          

        //    ////modelBuilder.Entity<Users>(entity =>
        //    //{
        //    //    entity.HasKey(e => e.userid)
        //    //        .HasName("users_pkey");

        //    //    entity.ToTable("users");

        //    //    entity.Property(e => e.userid).HasColumnName("userid");

             
        //    //      entity.Property(e => e.firstname)
        //    //        .HasMaxLength(100)
        //    //        .HasColumnName("firstname");

        //    //    entity.Property(e => e.lastname)
        //    //        .HasMaxLength(300)
        //    //        .HasColumnName("lastname");

        //    //    entity.Property(e => e.Isactive).HasColumnName("isactive");

        //    //    entity.Property(e => e.Lastlogindate).HasColumnName("lastlogindate");

        //    //    entity.Property(e => e.Logincount).HasColumnName("logincount");

        //    //    entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

        //    //    entity.Property(e => e.Modifiedon).HasColumnName("modifiedon");

        //    //    entity.Property(e => e.Passwordhash).HasColumnName("passwordhash");

        //    //    entity.Property(e => e.Passwordsalt).HasColumnName("passwordsalt");

        //    //    entity.Property(e => e.Roleid).HasColumnName("roleid");

        //    //    entity.Property(e => e.Username)
        //    //        .HasMaxLength(100)
        //    //        .HasColumnName("username");

        //    //    entity.HasOne(d => d.Role)
        //    //        .WithMany(p => p.AdminUsers)
        //    //        .HasForeignKey(d => d.Roleid)
        //    //        .HasConstraintName("roleid_fk");
        //    //});

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
