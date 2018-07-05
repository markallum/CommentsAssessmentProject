using CommentsAssessmentProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentsAssessmentProject.Services
{
    public class DbService : DbContext
    {
        public DbService(DbContextOptions<DbService> options) : base(options) { }

        public DbSet<Comment> Comments { get; set; }
    }
}
