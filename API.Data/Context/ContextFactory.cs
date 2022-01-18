using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usado para criar migrações
            //var connectionSring = @"Data Source=10.11.12.99; Database=CnxBackOffice; MultipleActiveResultSets=true; User ID=sa; Password=Cnxsql2015";
            var connectionSring = "Server=LAPTOP-M6V6FQOH\\SQLEXPRESS;Database=Backoffice;Trusted_Connection=True;";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer(connectionSring);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
