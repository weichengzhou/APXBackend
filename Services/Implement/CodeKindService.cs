
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
    public class CodeKindService : ICodeKindService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CodeKindService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }


        public async Task<CodeKind> Create(CodeKindDto kindDto)
        {
            IValidator validator = new CodeKindDtoValidator(kindDto);
            if(!validator.IsValidated())
                throw(new InputValidatedError(validator.GetErrors()));
            else if(await this.IsExistByName(kindDto.Name))
                throw(new CodeKindIsExistError(kindDto.Name));

            CodeKind createdKind = this._mapper.Map<CodeKind>(kindDto);
            
            await this._unitOfWork.CodeKindRepository.Create(createdKind);
            await this._unitOfWork.SaveChanges();
            return createdKind;
        }


        public async Task<bool> IsExistByName(string name)
        {
            
            return await this._unitOfWork.CodeKindRepository.IsExistByName(name);
        }


        public async Task<IEnumerable<CodeKind>> FindAll()
        {
            return await this._unitOfWork.CodeKindRepository.FindAll();
        }


        public async Task<CodeKind> FindByName(string name)
        {
            if(!await this.IsExistByName(name))
                throw(new CodeKindNotFoundError(name));
            return await this._unitOfWork.CodeKindRepository.FindByName(name);
        }


        public async Task<CodeKind> UpdateByName(string name, CodeKindDto kindDto)
        {
            CodeKind findKind= await this.FindByName(name);
            kindDto.Name = name;
            IValidator validator = new CodeKindDtoValidator(kindDto);
            if(!validator.IsValidated())
                throw(new InputValidatedError(validator.GetErrors()));

            CodeKind updatedKind = this._mapper.Map(kindDto, findKind);

            this._unitOfWork.CodeKindRepository.Update(updatedKind);
            await this._unitOfWork.SaveChanges();
            return updatedKind;
        }
    }
}