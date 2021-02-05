
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APX.Models.Context.Mapper
{
    public class TokenMapper : ITokenMapper
    {
        private EntityTypeBuilder<Token> _builder;

        public TokenMapper(EntityTypeBuilder<Token> builder)
        {
            this._builder = builder;
        }


        public void Map()
        {
            this.HasKey();
            this.SetTableName();
            this.MapSEQ();
            this.MapBody();
            this.MapCreatedUser();
            this.MapCreatedDate();
            this.MapUpdatedUser();
            this.MapUpdatedDate();
        }


        public void HasKey()
        {
            this._builder.HasKey(e => e.SEQ);
        }


        public void SetTableName()
        {
            this._builder.ToTable("tbAPX00001");
        }


        public void MapSEQ()
        {
            this._builder.Property(e => e.SEQ)
                .HasColumnName("Token_SEQ");
        }


        public void MapBody()
        {
            this._builder.Property(e => e.Body)
                .HasColumnName("TK_Body");
        }


        public void MapCreatedUser()
        {
            this._builder.Property(e => e.CreatedUser)
                .HasColumnName("CRE_USRID")
                .HasMaxLength(50)
                .IsRequired();
        }


        public void MapCreatedDate()
        {
            this._builder.Property(e => e.CreatedDate)
                .HasColumnName("CRE_DT")
                .IsRequired();
        }


        public void MapUpdatedUser()
        {
            this._builder.Property(e => e.UpdatedUser)
                .HasColumnName("UPD_USRID")
                .HasMaxLength(50)
                .IsRequired();
        }


        public void MapUpdatedDate()
        {
            this._builder.Property(e => e.UpdatedDate)
                .HasColumnName("UPD_DT")
                .IsRequired();
        }
    }
}