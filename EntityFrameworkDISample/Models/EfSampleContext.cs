using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace EntityFrameworkDISample.Models
{
    public class EfSampleContext : DbContext
    {
         public EfSampleContext()
            : base("DefaultConnection")
        {}

        public DbSet<Person> People { get; set; }

        public static void InitializeDatabase()
        {
            Database.SetInitializer<EfSampleContext>(null);
            try
            {
                using (var context = new EfSampleContext())
                {
                    if (!context.Database.Exists())
                    {
                        ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                    }
                }
            }
            catch (Exception ex)
            {
                    throw new InvalidOperationException(
                        "The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588",
                        ex);
            }
            
        }
    }
}