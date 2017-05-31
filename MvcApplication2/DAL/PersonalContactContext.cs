using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using MvcApplication2.Models;

namespace MvcApplication2.DAL
{
    public class PersonalContactContext : DbContext
    {
        public PersonalContactContext()
            : base("PersonalContactContext")
        {
        }

        public DbSet<PersonalContactModel> PersonalContacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}