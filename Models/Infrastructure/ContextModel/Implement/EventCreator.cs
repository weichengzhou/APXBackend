
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APX.Models.Context.Creator
{
    public class EventCreator : IEventCreator
    {
        private EntityTypeBuilder<Event> _builder;

        public EventCreator(EntityTypeBuilder<Event> builder)
        {
            this._builder = builder;
        }


        public void Create()
        {
            this.HasKey();
            this.SetTableName();
            this.CreateSEQ();
            this.CreateAPISystem();
            this.CreateAPIName();
            this.CreateAPIVersion();
            this.CreateSource();
            this.CreateName();
            this.CreateTime();
            this.CreateFlow();
            this.CreateIPAddress();
            this.CreateStatus();
            this.CreateDesc();
            this.CreateCreatedUser();
            this.CreateCreatedDate();
            this.CreateUpdatedUser();
            this.CreateUpdatedDate();
        }


        public void HasKey()
        {
            this._builder.HasKey(e => e.SEQ);
        }

        public void SetTableName()
        {
            this._builder.ToTable("tbAPX00002");
        }

        public void CreateSEQ()
        {   
            this._builder.Property(e => e.SEQ)
                .HasColumnName("eventSEQ");
        }

        public void CreateAPISystem()
        {
            this._builder.Property(e => e.APISystem)
                .HasColumnName("APISystem")
                .HasMaxLength(16)
                .IsRequired();
        }

        public void CreateAPIName()
        {
            this._builder.Property(e => e.APIName)
                .HasColumnName("API")
                .HasMaxLength(64)
                .IsRequired();
        }

        public void CreateAPIVersion()
        {
            this._builder.Property(e => e.APIVersion)
                .HasColumnName("APIVersion")
                .HasMaxLength(8);
        }

        public void CreateSource()
        {
            this._builder.Property(e => e.Source)
                .HasColumnName("eventSource")
                .HasMaxLength(64)
                .IsRequired();
        }

        public void CreateName()
        {
            this._builder.Property(e => e.Name)
                .HasColumnName("eventName")
                .HasMaxLength(64);
        }
    
        public void CreateTime()
        {
            this._builder.Property(e => e.Time)
                .HasColumnName("eventTime")
                .IsRequired();
        }

        public void CreateFlow()
        {
            this._builder.Property(e => e.Flow)
                .HasColumnName("eventFlow")
                .HasMaxLength(30)
                .IsRequired();
        }

        public void CreateIPAddress()
        {
            this._builder.Property(e => e.IPAddress)
                .HasColumnName("eventIPAddress")
                .HasMaxLength(20);
        }

        public void CreateStatus()
        {
            this._builder.Property(e => e.Status)
                .HasColumnName("eventStatus")
                .HasMaxLength(255);
        }

        public void CreateDesc()
        {
            this._builder.Property(e => e.Desc)
                .HasColumnName("eventDESC")
                .HasMaxLength(255);
        }

        public void CreateCreatedUser()
        {
            this._builder.Property(e => e.CreatedUser)
                .HasColumnName("CRE_USRID")
                .HasMaxLength(50)
                .IsRequired();
        }

        public void CreateCreatedDate()
        {
            this._builder.Property(e => e.CreatedDate)
                .HasColumnName("CRE_DT")
                .IsRequired();
        }

        public void CreateUpdatedUser()
        {
            this._builder.Property(e => e.UpdatedUser)
                .HasColumnName("UPD_USRID")
                .HasMaxLength(50)
                .IsRequired();
        }

        public void CreateUpdatedDate()
        {
            this._builder.Property(e => e.UpdatedDate)
                .HasColumnName("UPD_DT")
                .IsRequired();
        }
    }
}