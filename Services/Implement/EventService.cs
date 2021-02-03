
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using APX.Models;
using APX.Services.UnitOfWork;
using APX.Services.Parameter;
using APX.Services.Exceptions;

namespace APX.Services
{
    public class EventService : IEventService
    {
        private IUnitOfWork _unitOfWork;

        public EventService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        public async Task<Event> Create(IParameter parameter)
        {
            CreatedEventParameter para = (CreatedEventParameter)parameter;
            if(!para.IsValidated())
                throw(new InputValidatedError(para.GetErrors()));

            Event createdEvent = new Event{
                APISystem = para.APISystem,
                APIName = para.APIName,
                APIVersion = para.APIVersion,
                Source = para.Source,
                Name = para.Name,
                Time = para.GetTime(),
                Flow = para.Flow,
                IPAddress = para.IPAddress,
                Status = para.Status,
                Desc = para.Desc,
                CreatedUser = para.CreatedUser,
                CreatedDate = DateTime.Now,
                UpdatedUser = para.CreatedUser,
                UpdatedDate = DateTime.Now
            };
            await this._unitOfWork.EventRepository.Create(createdEvent);
            await this._unitOfWork.SaveChanges();
            return createdEvent;
        }


        public async Task<bool> IsExistBySeq(string seq)
        {
            return await this._unitOfWork.EventRepository.IsExistBySeq(seq);
        }



        public async Task<IEnumerable<Event>> FindAll()
        {
            return await this._unitOfWork.EventRepository.FindAll();
        }


        public async Task<Event> FindBySeq(string seq)
        {
            if(!await this.IsExistBySeq(seq))
                throw(new EventNotFoundError(seq));
            return await this._unitOfWork.EventRepository.FindBySeq(seq);
        }


        public async Task<Event> UpdateBySeq(string seq, IParameter parameter)
        {
            UpdatedEventParameter para = (UpdatedEventParameter)parameter;
            if(!para.IsValidated())
                throw(new InputValidatedError(para.GetErrors()));

            Event updatedEvent = await this.FindBySeq(seq);
            updatedEvent.APISystem = para.APISystem ?? updatedEvent.APISystem;
            updatedEvent.APIName = para.APIName ?? updatedEvent.APIName;
            updatedEvent.APIVersion = para.APIVersion ?? updatedEvent.APIVersion;
            updatedEvent.Source = para.Source ?? updatedEvent.Source;
            updatedEvent.Name = para.Name ?? updatedEvent.Name;
            updatedEvent.Time = para.GetTime() ?? updatedEvent.Time;
            updatedEvent.Flow = para.Flow ?? updatedEvent.Flow;
            updatedEvent.IPAddress = para.IPAddress ?? updatedEvent.IPAddress;
            updatedEvent.Status = para.Status ?? updatedEvent.Status;
            updatedEvent.Desc = para.Desc ?? updatedEvent.Desc;
            updatedEvent.UpdatedUser = para.UpdatedUser;
            updatedEvent.UpdatedDate = DateTime.Now;
            this._unitOfWork.EventRepository.Update(updatedEvent);
            await this._unitOfWork.SaveChanges();
            return updatedEvent;
        }
    }
}