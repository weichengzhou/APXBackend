
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APX.Models.Context.Creator
{
    public class CodeKindCreator : ICodeKindCreator
    {
        private EntityTypeBuilder<CodeKind> _builder;

        public CodeKindCreator(EntityTypeBuilder<CodeKind> builder)
        {
            this._builder = builder;
        }


        public void Create()
        {
            this.HasKey();
            this.SetTableName();
            this.CreateName();
            this.CreateNameT();
        }


        public void HasKey()
        {
            this._builder.HasKey(e => e.Name);
        }


        public void SetTableName()
        {
            this._builder.ToTable("tbAPX00003");
        }


        public void CreateName()
        {
            this._builder.Property(e => e.Name)
                .HasColumnName("CODE_KIND")
                .HasMaxLength(10)
                .IsRequired();
        }


        public void CreateNameT()
        {
            this._builder.Property(e => e.NameT)
                .HasColumnName("CODE_KIND_T")
                .HasMaxLength(20);
        }
    }
}