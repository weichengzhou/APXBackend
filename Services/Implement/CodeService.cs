
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
    public class CodeService : ICodeService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CodeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }


        public async Task<Code> Create(CreateCodeDto codeDto)
        {
            IValidator validator = new CreateCodeDtoValidator(codeDto);
            if(!validator.IsValidated())
                throw(new InputValidatedError(validator.GetErrors()));
            else if(await this.IsExistById(codeDto.Id))
                throw(new CodeIsExistError(codeDto.Id));
            else if(!await this._unitOfWork.CodeKindRepository
                .IsExistByName(codeDto.Kind))
                throw(new CodeKindNotFoundError(codeDto.Kind));

            Code createdCode = this._mapper.Map<Code>(codeDto);
            
            await this._unitOfWork.CodeRepository.Create(createdCode);
            await this._unitOfWork.SaveChanges();
            return createdCode;
        }


        public async Task<bool> IsExistById(string id)
        {
            return await this._unitOfWork.CodeRepository.IsExistById(id);
        }


        public async Task<IEnumerable<Code>> FindAll()
        {
            return await this._unitOfWork.CodeRepository.FindAll();
        }


        public async Task<Code> FindById(string id)
        {
            if(!await this.IsExistById(id))
                throw(new CodeNotFoundError(id));
            return await this._unitOfWork.CodeRepository.FindById(id);
        }


        public async Task<Code> UpdateById(string id, UpdateCodeDto codeDto)
        {
            Code findCode = await this.FindById(id);
            IValidator validator = new UpdateCodeDtoValidator(codeDto);
            if(!validator.IsValidated())
                throw(new InputValidatedError(validator.GetErrors()));
            if(codeDto.Kind != null &
                !await this._unitOfWork.CodeKindRepository.IsExistByName(codeDto.Kind))
                throw(new CodeKindNotFoundError(codeDto.Kind));

            Code updatedCode = this._mapper.Map(codeDto, findCode);
            
            this._unitOfWork.CodeRepository.Update(updatedCode);
            await this._unitOfWork.SaveChanges();
            return updatedCode;
        }
    }
}