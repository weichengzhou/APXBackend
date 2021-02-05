
using Microsoft.EntityFrameworkCore;

using APX.Models.Context.Creator;

namespace APX.Models.Context
{
    public class APXContext : DbContext
    {
        public APXContext(DbContextOptions options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.CreateCodeModel(modelBuilder);
            this.CreateCodeKindModel(modelBuilder);
            this.CreateEventModel(modelBuilder);
            this.CreateTokenModel(modelBuilder);
        }


        private void CreateTokenModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Token>(builder => {
                ITokenCreator creator = new TokenCreator(builder);
                creator.Create();
            });
        }

        
        private void CreateCodeModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Code>(builder => {
                ICodeCreator creator = new CodeCreator(builder);
                creator.Create();
            });
        }


        private void CreateCodeKindModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CodeKind>(builder => {
                ICodeKindCreator creator = new CodeKindCreator(builder);
                creator.Create();
            });
        }

        
        private void CreateEventModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(buidler => {
                IEventCreator creator = new EventCreator(buidler);
                creator.Create();
            });
        }


        public virtual DbSet<Code> Codes { get; set; }
        
        public virtual DbSet<CodeKind> CodeKinds { get; set; }

        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<Token> Tokens { get; set; }
    }
}