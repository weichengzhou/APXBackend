
namespace APX.Models.Context.Mapper
{
    // Interface: Dbcontext mapper.
    public interface IContextMapper
    {
        // Mapping all fields in table.
        void Map();

        // Set the primary key of table.
        void HasKey();

        // Set the name of table in database.
        void SetTableName();
    }
}