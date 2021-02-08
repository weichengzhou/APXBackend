
namespace APX.Models.Context.Mapper
{
    // Defined the fields in Token which need to mapping.
    public interface ITokenMapper : IContextMapper
    {
        void MapSEQ();

        void MapBody();

        void MapCreatedUser();

        void MapCreatedDate();

        void MapUpdatedUser();

        void MapUpdatedDate();
    }
}