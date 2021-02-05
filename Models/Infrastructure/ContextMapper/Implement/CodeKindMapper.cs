
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APX.Models.Context.Mapper
{
    public class CodeKindMapper : ICodeKindMapper
    {
        private EntityTypeBuilder<CodeKind> _builder;

        public CodeKindMapper(EntityTypeBuilder<CodeKind> builder)
        {
            this._builder = builder;
        }


        public void Map()
        {
            this.HasKey();
            this.SetTableName();
            this.MapName();
            this.MapNameT();
        }


        public void HasKey()
        {
            this._builder.HasKey(e => e.Name);
        }


        public void SetTableName()
        {
            this._builder.ToTable("tbAPX00003");
        }


        public void MapName()
        {
            this._builder.Property(e => e.Name)
                .HasColumnName("CODE_KIND")
                .HasMaxLength(10)
                .IsRequired();
        }


        public void MapNameT()
        {
            this._builder.Property(e => e.NameT)
                .HasColumnName("CODE_KIND_T")
                .HasMaxLength(20);
        }
    }
}