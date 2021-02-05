
namespace APX.Models.Context.Mapper
{
    // Map fields to table `Code`.
    public interface ICodeMapper : IContextMapper
    {
        void MapId();

        void MapKind();

        void MapSortOrder();

        void MapNameT();
        
        void MapContent();
    }
}