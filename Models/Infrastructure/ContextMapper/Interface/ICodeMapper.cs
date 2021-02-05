
namespace APX.Models.Context.Mapper
{
    public interface ICodeMapper : IContextMapper
    {
        void MapId();

        void MapKind();

        void MapSortOrder();

        void MapNameT();
        
        void MapContent();
    }
}