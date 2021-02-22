
namespace APX.Models.Context.Mapper
{
    // Interface: Dbcontext mapper.
    public interface IContextMapper
    {
        // Maps model into table.
        void Map();

        // Defines the key of table.
        void HasKey();

        // Defines the name of table.
        void SetTableName();
    }
}