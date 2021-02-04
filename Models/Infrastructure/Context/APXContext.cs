
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<Token>(entity => {
                entity.HasKey(e => e.SEQ);
                entity.ToTable("tbAPX00001");
                entity.Property(e => e.SEQ)
                    .HasColumnName("Token_SEQ");
                entity.Property(e => e.Body)
                    .HasColumnName("TK_Body");
                entity.Property(e => e.CreatedUser)
                    .HasColumnName("CRE_USRID")
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CRE_DT")
                    .IsRequired();
                entity.Property(e => e.UpdatedUser)
                    .HasColumnName("UPD_USRID")
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UPD_DT")
                    .IsRequired();
            });
        }

        
        private void CreateCodeModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Code>(entity => {
                entity.HasKey(e => e.Id);
                entity.ToTable("tbAPX00004");
                entity.Property(e => e.Id)
                    .HasColumnName("CODE_ID")
                    .HasMaxLength(3)
                    .IsRequired();
                entity.Property(e => e.Kind)
                    .HasColumnName("CODE_KIND")
                    .HasMaxLength(10)
                    .IsRequired();
                entity.Property(e => e.SortOrder)
                    .HasColumnName("SORT_ORDER")
                    .HasMaxLength(7);
                entity.Property(e => e.NameT)
                    .HasColumnName("CODE_T")
                    .HasMaxLength(20);
                entity.Property(e => e.Content)
                    .HasColumnName("CODE_CONTENT")
                    .HasMaxLength(50);
            });
        }


        private void CreateCodeKindModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CodeKind>(entity => {
                entity.HasKey(e => e.Name);
                entity.ToTable("tbAPX00003");
                entity.Property(e => e.Name)
                    .HasColumnName("CODE_KIND")
                    .HasMaxLength(10)
                    .IsRequired();
                entity.Property(e => e.NameT)
                    .HasColumnName("CODE_KIND_T")
                    .HasMaxLength(20);
            });
        }

        
        private void CreateEventModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity => {
                entity.HasKey(e => e.SEQ);
                entity.ToTable("tbAPX00002");
                entity.Property(e => e.SEQ)
                    .HasColumnName("eventSEQ");
                entity.Property(e => e.APISystem)
                    .HasColumnName("APISystem")
                    .HasMaxLength(16)
                    .IsRequired();
                entity.Property(e => e.APIName)
                    .HasColumnName("API")
                    .HasMaxLength(64)
                    .IsRequired();
                entity.Property(e => e.APIVersion)
                    .HasColumnName("APIVersion")
                    .HasMaxLength(8);
                entity.Property(e => e.Source)
                    .HasColumnName("eventSource")
                    .HasMaxLength(64)
                    .IsRequired();
                entity.Property(e => e.Name)
                    .HasColumnName("eventName")
                    .HasMaxLength(64);
                entity.Property(e => e.Time)
                    .HasColumnName("eventTime")
                    .IsRequired();
                entity.Property(e => e.Flow)
                    .HasColumnName("eventFlow")
                    .HasMaxLength(30)
                    .IsRequired();
                entity.Property(e => e.IPAddress)
                    .HasColumnName("eventIPAddress")
                    .HasMaxLength(20);
                entity.Property(e => e.Status)
                    .HasColumnName("eventStatus")
                    .HasMaxLength(255);
                entity.Property(e => e.Desc)
                    .HasColumnName("eventDESC")
                    .HasMaxLength(255);
                entity.Property(e => e.CreatedUser)
                    .HasColumnName("CRE_USRID")
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CRE_DT")
                    .IsRequired();
                entity.Property(e => e.UpdatedUser)
                    .HasColumnName("UPD_USRID")
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UPD_DT")
                    .IsRequired();
            });
        }


        public virtual DbSet<Code> Codes { get; set; }
        
        public virtual DbSet<CodeKind> CodeKinds { get; set; }

        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<Token> Tokens { get; set; }
    }
}