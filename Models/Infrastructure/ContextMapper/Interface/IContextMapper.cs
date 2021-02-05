
namespace APX.Models.Context.Mapper
{
    public interface IContextMapper
    {
        void Map();

        void HasKey();

        void SetTableName();

    }
}