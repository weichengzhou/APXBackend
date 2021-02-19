
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using APX.Models;
using APX.Models.Dto;
using APX.Services.UnitOfWork;
using APX.Services.Validator;
using APX.Services.Exceptions;

namespace APX.Services
{
    public class EventService : IEventService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public EventService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }


        public async Task<Event> Create(EventDto eventDto)
        {
            IValidator validator = ValidatorFactory.CreateDtoValidator(eventDto);
            if(!validator.IsValidated())
                throw(new InputValidatedError(validator.GetErrors()));

            Event createdEvent = this._mapper.Map<Event>(eventDto);
            createdEvent.UpdatedUser = createdEvent.CreatedUser;
            createdEvent.CreatedDate = DateTime.Now;

            await this._unitOfWork.EventRepository.Create(createdEvent);
            await this._unitOfWork.SaveChanges();
            return createdEvent;
        }


        public async Task<bool> IsExistBySEQ(string seq)
        {
            return await this._unitOfWork.EventRepository.IsExistBySEQ(seq);
        }



        public async Task<IEnumerable<Event>> FindAll()
        {
            return await this._unitOfWork.EventRepository.FindAll();
        }


        public async Task<Event> FindBySEQ(string seq)
        {
            if(!await this.IsExistBySEQ(seq))
                throw(new EventNotFoundError(seq));
            return await this._unitOfWork.EventRepository.FindBySEQ(seq);
        }


        public async Task<Event> UpdateBySEQ(string seq, EventDto eventDto)
        {
            Event findEvent = await this.FindBySEQ(seq);
            eventDto.CreatedUser = findEvent.CreatedUser;
            IValidator validator = ValidatorFactory.UpdateDtoValidator(eventDto);
            if(!validator.IsValidated())
                throw(new InputValidatedError(validator.GetErrors()));
            
            Event updatedEvent = this._mapper.Map(eventDto, findEvent);
            
            this._unitOfWork.EventRepository.Update(updatedEvent);
            await this._unitOfWork.SaveChanges();
            return updatedEvent;
        }
    }
}