
namespace APX.Models.Context.Mapper
{
    // Provide Mapper to map table.
    public interface IContextMapper
    {
        // Just call Map function, mapping table.
        void Map();

        // Set the Primary Key of table.
        void HasKey();

        // Set the table name in real database.
        void SetTableName();

    }
}