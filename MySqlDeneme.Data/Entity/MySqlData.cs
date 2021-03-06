﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MySqlDeneme.Data.Models;

namespace MySqlDeneme.Data.Entity
{
    public interface IMySqlData
    {
        DbSet<Menu> Menus { get; set; }

        Task<int> SaveChangesAsync();
    }

    public class MySqlData : DbContext, IMySqlData
    {
        public MySqlData(DbContextOptions options) : base(options) { }

        public void MigrateDatabase(bool isDevelopment = false)
        {
            Database.Migrate();
        }

        public Task<int> SaveChangesAsync()
        {
            return SaveChangesAsync(cancellationToken: default(CancellationToken));
        }

        public DbSet<Menu> Menus { get; set; }
    }

    public class MySqlDataFactory : IDesignTimeDbContextFactory<MySqlData>
    {
        public MySqlData CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MySqlData>();
            optionsBuilder.UseMySql("server=db4free.net;port=3306;database=mysqltestyasin;uid=mysqltestadmin;password=jv0ıtT4&3@;");

            return new MySqlData(optionsBuilder.Options);
        }
    }
}
