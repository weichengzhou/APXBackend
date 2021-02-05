
namespace APX.Models.Context.Mapper
{
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