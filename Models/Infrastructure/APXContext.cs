
using Microsoft.EntityFrameworkCore;

using APX.Models.Context.Mapper;

namespace APX.Models.Context
{
    public class APXContext : DbContext
    {
        public APXContext(DbContextOptions options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapperFactory.CreateMapper(modelBuilder.Entity<Code>()).Map();
            MapperFactory.CreateMapper(modelBuilder.Entity<CodeKind>()).Map();
            MapperFactory.CreateMapper(modelBuilder.Entity<Event>()).Map();
            MapperFactory.CreateMapper(modelBuilder.Entity<Token>()).Map();
        }


        public virtual DbSet<Code> Codes { get; set; }
        
        public virtual DbSet<CodeKind> CodeKinds { get; set; }

        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<Token> Tokens { get; set; }
    }
}