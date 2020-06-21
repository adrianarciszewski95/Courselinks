using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace CourseLinksAPI.Models
{
    public class CourseContext : IdentityDbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options)
            : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
    }

    
}
