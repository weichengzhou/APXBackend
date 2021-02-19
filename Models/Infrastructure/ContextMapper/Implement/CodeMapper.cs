using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APX.Models.Context.Mapper
{
    /* Usage:
       CodeMapper mapper = new CodeMapper(builder);
       mapper.Map();
    */
    public class CodeMapper : ICodeMapper
    {
        private EntityTypeBuilder<Code> _builder;

        public CodeMapper(EntityTypeBuilder<Code> builder)
        {
            this._builder = builder;
        }


        // Map all fields in Code.
        public void Map()
        {
            this.HasKey();
            this.SetTableName();
            this.MapId();
            this.MapKind();
            this.MapSortOrder();
            this.MapNameT();
            this.MapContent();
        }


        public void HasKey()
        {
            this._builder.HasKey(e => e.ID);
        }


        public void SetTableName()
        {
            this._builder.ToTable("tbAPX00004");
        }


        public void MapId()
        {
            this._builder.Property(e => e.ID)
                .HasColumnName("CODE_ID")
                .HasMaxLength(3)
                .IsRequired();
        }


        public void MapKind()
        {
            this._builder.Property(e => e.Kind)
                .HasColumnName("CODE_KIND")
                .HasMaxLength(10)
                .IsRequired();
        }


        public void MapSortOrder()
        {
            this._builder.Property(e => e.SortOrder)
                .HasColumnName("SORT_ORDER")
                .HasMaxLength(7);
        }


        public void MapNameT()
        {
            this._builder.Property(e => e.NameT)
                .HasColumnName("CODE_T")
                .HasMaxLength(20);
        }


        public void MapContent()
        {
            this._builder.Property(e => e.Content)
                .HasColumnName("CODE_CONTENT")
                .HasMaxLength(50);
        }
    }
}