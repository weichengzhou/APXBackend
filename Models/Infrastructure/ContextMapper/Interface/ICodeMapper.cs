
namespace APX.Models.Context.Mapper
{
    // Defined the fields in Code which need to mapping.
    public interface ICodeMapper : IContextMapper
    {
        void MapId();

        void MapKind();

        void MapSortOrder();

        void MapNameT();
        
        void MapContent();
    }
}