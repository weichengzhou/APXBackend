
namespace APX.Models.Context.Creator
{
    public interface IContextCreator
    {
        void Create();

        void HasKey();

        void SetTableName();

    }
}