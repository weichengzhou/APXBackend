
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


        public async Task<Event> Create(CreateEventDto eventDto)
        {
            IValidator validator = new CreateEventDtoValidator(eventDto);
            if(!validator.IsValidated())
                throw(new InputValidatedError(validator.GetErrors()));

            Event createdEvent = this._mapper.Map<Event>(eventDto);

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


        public async Task<Event> UpdateBySeq(string seq, UpdateEventDto eventDto)
        {
            Event findEvent = await this.FindBySeq(seq);
            IValidator validator = new UpdateEventDtoValidator(eventDto);
            if(!validator.IsValidated())
                throw(new InputValidatedError(validator.GetErrors()));
            
            Event updatedEvent = this._mapper.Map(eventDto, findEvent);
            
            this._unitOfWork.EventRepository.Update(updatedEvent);
            await this._unitOfWork.SaveChanges();
            return updatedEvent;
        }
    }
}