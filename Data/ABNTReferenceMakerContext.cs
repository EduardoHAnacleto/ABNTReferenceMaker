using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ABNTReferenceMaker.Models;

namespace ABNTReferenceMaker.Data
{
    public class ABNTReferenceMakerContext : DbContext
    {
        public ABNTReferenceMakerContext (DbContextOptions<ABNTReferenceMakerContext> options)
            : base(options)
        {
        }

        public DbSet<ABNTReferenceMaker.Models.Author> Author { get; set; } = default!;

        public DbSet<ABNTReferenceMaker.Models.Paper>? Paper { get; set; }

        public DbSet<ABNTReferenceMaker.Models.Book>? Book { get; set; }

        public DbSet<ABNTReferenceMaker.Models.Website>? Website { get; set; }

        public DbSet<ABNTReferenceMaker.Models.Magazine>? Magazine { get; set; }
    }
}
