using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InMotion.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InMotion.Data.Access {
	public class ApplicationDbContext : IdentityDbContext {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) {
                     Database.Migrate();
        }

		public DbSet<Message> Messages { get;set;}
		public DbSet<Movie>  Movies { get; set; }
	}
}
