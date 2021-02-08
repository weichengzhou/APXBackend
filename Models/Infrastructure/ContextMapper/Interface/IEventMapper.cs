
namespace APX.Models.Context.Mapper
{
    // Defined the fields in Event which need to mapping.
    public interface IEventMapper : IContextMapper
    {
        void MapSEQ();

        void MapAPISystem();

        void MapAPIName();

        void MapAPIVersion();

        void MapSource();

        void MapName();
    
        void MapTime();

        void MapFlow();

        void MapIPAddress();

        void MapStatus();

        void MapDesc();

        void MapCreatedUser();

        void MapCreatedDate();

        void MapUpdatedUser();

        void MapUpdatedDate();
    }
}