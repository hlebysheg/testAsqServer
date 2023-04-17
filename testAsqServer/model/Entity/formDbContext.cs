using System;
using Microsoft.EntityFrameworkCore;

namespace testAsqServer.model.Entity
{
	public class FormDbContext: DbContext
	{
        public FormDbContext(DbContextOptions<FormDbContext> options)
            : base(options)
        {
        }

        public DbSet<FileInfo> FileInfo { get; set; }
        public DbSet<OOOForm> OOOForm { get; set; }
        public DbSet<PayForm> PayForm { get; set; }
        public DbSet<StandartIPForm> StandartIPForm { get; set; }
    }
}

