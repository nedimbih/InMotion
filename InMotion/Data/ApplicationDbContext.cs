using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InMotion.Data {
	public class ApplicationDbContext : IdentityDbContext {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) {
                     Database.Migrate();
        }
	}
}
