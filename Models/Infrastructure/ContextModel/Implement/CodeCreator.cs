using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APX.Models.Context.Creator
{
    public class CodeCreator : ICodeCreator
    {
        private EntityTypeBuilder<Code> _builder;

        public CodeCreator(EntityTypeBuilder<Code> builder)
        {
            this._builder = builder;
        }


        public void Create()
        {
            this.HasKey();
            this.SetTableName();
            this.CreateId();
            this.CreateKind();
            this.CreateSortOrder();
            this.CreateNameT();
            this.CreateContent();
        }


        public void HasKey()
        {
            this._builder.HasKey(e => e.Id);
        }


        public void SetTableName()
        {
            this._builder.ToTable("tbAPX00004");
        }


        public void CreateId()
        {
            this._builder.Property(e => e.Id)
                .HasColumnName("CODE_ID")
                .HasMaxLength(3)
                .IsRequired();
        }


        public void CreateKind()
        {
            this._builder.Property(e => e.Kind)
                .HasColumnName("CODE_KIND")
                .HasMaxLength(10)
                .IsRequired();
        }


        public void CreateSortOrder()
        {
            this._builder.Property(e => e.SortOrder)
                .HasColumnName("SORT_ORDER")
                .HasMaxLength(7);
        }


        public void CreateNameT()
        {
            this._builder.Property(e => e.NameT)
                .HasColumnName("CODE_T")
                .HasMaxLength(20);
        }


        public void CreateContent()
        {
            this._builder.Property(e => e.Content)
                .HasColumnName("CODE_CONTENT")
                .HasMaxLength(50);
        }
    }
}