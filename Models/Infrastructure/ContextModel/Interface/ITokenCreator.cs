
namespace APX.Models.Context.Creator
{
    public interface ITokenCreator : IContextCreator
    {
        void CreateSEQ();

        void CreateBody();

        void CreateCreatedUser();

        void CreateCreatedDate();

        void CreateUpdatedUser();

        void CreateUpdatedDate();
    }
}