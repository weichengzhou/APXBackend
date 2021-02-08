
namespace APX.Models.Context.Mapper
{
    // Defined the fields in CodeKind which need to mapping.
    public interface ICodeKindMapper : IContextMapper
    {
        void MapName();

        void MapNameT();
    }
}