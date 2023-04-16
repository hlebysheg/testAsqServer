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

        DbSet<FileInfo> FileInfo { get; set; }
        DbSet<OOOForm> OOOForm { get; set; }
        DbSet<PayForm> PayForm { get; set; }
        DbSet<StandartIPForm> StandartIPForm { get; set; }
    }
}

