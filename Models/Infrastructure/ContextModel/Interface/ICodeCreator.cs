
namespace APX.Models.Context.Creator
{
    public interface ICodeCreator : IContextCreator
    {
        void CreateId();

        void CreateKind();

        void CreateSortOrder();

        void CreateNameT();
        
        void CreateContent();
    }
}