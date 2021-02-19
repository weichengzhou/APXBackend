
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


        public async Task<Code> Create(CodeDto codeDto)
        {
            IValidator validator = ValidatorFactory.CreateDtoValidator(codeDto);
            if(!validator.IsValidated())
                throw(new InputValidatedError(validator.GetErrors()));
            else if(await this.IsExistByID(codeDto.ID))
                throw(new CodeIsExistError(codeDto.ID));
            else if(!await this._unitOfWork.CodeKindRepository
                .IsExistByName(codeDto.Kind))
                throw(new CodeKindNotFoundError(codeDto.Kind));

            Code createdCode = this._mapper.Map<Code>(codeDto);
            
            await this._unitOfWork.CodeRepository.Create(createdCode);
            await this._unitOfWork.SaveChanges();
            return createdCode;
        }


        public async Task<bool> IsExistByID(string id)
        {
            return await this._unitOfWork.CodeRepository.IsExistByID(id);
        }


        public async Task<IEnumerable<Code>> FindAll()
        {
            return await this._unitOfWork.CodeRepository.FindAll();
        }


        public async Task<Code> FindByID(string id)
        {
            if(!await this.IsExistByID(id))
                throw(new CodeNotFoundError(id));
            return await this._unitOfWork.CodeRepository.FindByID(id);
        }


        public async Task<Code> UpdateByID(string id, CodeDto codeDto)
        {
            Code findCode = await this.FindByID(id);
            codeDto.ID = id;
            IValidator validator = ValidatorFactory.UpdateDtoValidator(codeDto);
            if(!validator.IsValidated())
                throw(new InputValidatedError(validator.GetErrors()));
            if(!await this._unitOfWork.CodeKindRepository.IsExistByName(codeDto.Kind))
                throw(new CodeKindNotFoundError(codeDto.Kind));

            Code updatedCode = this._mapper.Map(codeDto, findCode);
            
            this._unitOfWork.CodeRepository.Update(updatedCode);
            await this._unitOfWork.SaveChanges();
            return updatedCode;
        }
    }
}