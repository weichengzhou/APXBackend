
namespace APX.Models.Context.Creator
{
    public interface IEventCreator : IContextCreator
    {
        void CreateSEQ();

        void CreateAPISystem();

        void CreateAPIName();

        void CreateAPIVersion();

        void CreateSource();

        void CreateName();
    
        void CreateTime();

        void CreateFlow();

        void CreateIPAddress();

        void CreateStatus();

        void CreateDesc();

        void CreateCreatedUser();

        void CreateCreatedDate();

        void CreateUpdatedUser();

        void CreateUpdatedDate();
    }
}