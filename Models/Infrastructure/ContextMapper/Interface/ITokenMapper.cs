
namespace APX.Models.Context.Mapper
{
    // Map fields to table `Token`.
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