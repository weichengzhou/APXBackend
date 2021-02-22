
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APX.Models.Context.Mapper
{
    /* Usage:
    |  EventMapper mapper = new EventMapper(builder);
    |  mapper.Map();
    */
    public class EventMapper : IEventMapper
    {
        private EntityTypeBuilder<Event> _builder;

        public EventMapper(EntityTypeBuilder<Event> builder)
        {
            this._builder = builder;
        }


        public void Map()
        {
            this.HasKey();
            this.SetTableName();
            this.MapSEQ();
            this.MapAPISystem();
            this.MapAPIName();
            this.MapAPIVersion();
            this.MapSource();
            this.MapName();
            this.MapTime();
            this.MapFlow();
            this.MapIPAddress();
            this.MapStatus();
            this.MapDesc();
            this.MapCreatedUser();
            this.MapCreatedDate();
            this.MapUpdatedUser();
            this.MapUpdatedDate();
        }


        public void HasKey()
        {
            this._builder.HasKey(e => e.SEQ);
        }

        public void SetTableName()
        {
            this._builder.ToTable("tbAPX00002");
        }

        public void MapSEQ()
        {   
            this._builder.Property(e => e.SEQ)
                .HasColumnName("eventSEQ");
        }

        public void MapAPISystem()
        {
            this._builder.Property(e => e.APISystem)
                .HasColumnName("APISystem")
                .HasMaxLength(16)
                .IsRequired();
        }

        public void MapAPIName()
        {
            this._builder.Property(e => e.APIName)
                .HasColumnName("API")
                .HasMaxLength(64)
                .IsRequired();
        }

        public void MapAPIVersion()
        {
            this._builder.Property(e => e.APIVersion)
                .HasColumnName("APIVersion")
                .HasMaxLength(8);
        }

        public void MapSource()
        {
            this._builder.Property(e => e.Source)
                .HasColumnName("eventSource")
                .HasMaxLength(64)
                .IsRequired();
        }

        public void MapName()
        {
            this._builder.Property(e => e.Name)
                .HasColumnName("eventName")
                .HasMaxLength(64);
        }
    
        public void MapTime()
        {
            this._builder.Property(e => e.Time)
                .HasColumnName("eventTime")
                .IsRequired();
        }

        public void MapFlow()
        {
            this._builder.Property(e => e.Flow)
                .HasColumnName("eventFlow")
                .HasMaxLength(30)
                .IsRequired();
        }

        public void MapIPAddress()
        {
            this._builder.Property(e => e.IPAddress)
                .HasColumnName("eventIPAddress")
                .HasMaxLength(20);
        }

        public void MapStatus()
        {
            this._builder.Property(e => e.Status)
                .HasColumnName("eventStatus")
                .HasMaxLength(255);
        }

        public void MapDesc()
        {
            this._builder.Property(e => e.Desc)
                .HasColumnName("eventDESC")
                .HasMaxLength(255);
        }

        public void MapCreatedUser()
        {
            this._builder.Property(e => e.CreatedUser)
                .HasColumnName("CRE_USRID")
                .HasMaxLength(50)
                .IsRequired();
        }

        public void MapCreatedDate()
        {
            this._builder.Property(e => e.CreatedDate)
                .HasColumnName("CRE_DT")
                .IsRequired();
        }

        public void MapUpdatedUser()
        {
            this._builder.Property(e => e.UpdatedUser)
                .HasColumnName("UPD_USRID")
                .HasMaxLength(50)
                .IsRequired();
        }

        public void MapUpdatedDate()
        {
            this._builder.Property(e => e.UpdatedDate)
                .HasColumnName("UPD_DT")
                .IsRequired();
        }
    }
}