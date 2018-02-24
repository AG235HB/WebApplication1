using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ASP_DB_Context:DbContext
    {
        public DbSet<Founder> Founders { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Relation> Relations { get; set; }
    }
}