
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APX.Models.Context.Creator
{
    public class TokenCreator : ITokenCreator
    {
        private EntityTypeBuilder<Token> _builder;

        public TokenCreator(EntityTypeBuilder<Token> builder)
        {
            this._builder = builder;
        }


        public void Create()
        {
            this.HasKey();
            this.SetTableName();
            this.CreateSEQ();
            this.CreateBody();
            this.CreateCreatedUser();
            this.CreateCreatedDate();
            this.CreateUpdatedUser();
            this.CreateUpdatedDate();
        }


        public void HasKey()
        {
            this._builder.HasKey(e => e.SEQ);
        }


        public void SetTableName()
        {
            this._builder.ToTable("tbAPX00001");
        }


        public void CreateSEQ()
        {
            this._builder.Property(e => e.SEQ)
                .HasColumnName("Token_SEQ");
        }


        public void CreateBody()
        {
            this._builder.Property(e => e.Body)
                .HasColumnName("TK_Body");
        }


        public void CreateCreatedUser()
        {
            this._builder.Property(e => e.CreatedUser)
                .HasColumnName("CRE_USRID")
                .HasMaxLength(50)
                .IsRequired();
        }


        public void CreateCreatedDate()
        {
            this._builder.Property(e => e.CreatedDate)
                .HasColumnName("CRE_DT")
                .IsRequired();
        }


        public void CreateUpdatedUser()
        {
            this._builder.Property(e => e.UpdatedUser)
                .HasColumnName("UPD_USRID")
                .HasMaxLength(50)
                .IsRequired();
        }


        public void CreateUpdatedDate()
        {
            this._builder.Property(e => e.UpdatedDate)
                .HasColumnName("UPD_DT")
                .IsRequired();
        }
    }
}