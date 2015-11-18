using Microsoft.AspNet.Identity.EntityFramework;
using Nightpath.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Nightpath.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }
        
        public DbSet<Review> Reviews { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Points> Points { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Establishment> Establishments { get; set; }

        public DbSet<Estab_Owner> Estab_Owners { get; set; }

        public DbSet<Client> Clients { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }



    }
