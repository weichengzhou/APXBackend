
using System.Threading.Tasks;
using System.Collections.Generic;

using APX.Models;
using APX.Services.UnitOfWork;
using APX.Services.Parameter;
using APX.Services.Exceptions;

namespace APX.Services
{
    public class CodeKindService : ICodeKindService
    {
        private IUnitOfWork _unitOfWork;

        public CodeKindService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        public async Task<CodeKind> Create(IParameter parameter)
        {
            CreatedCodeKindParameter para = (CreatedCodeKindParameter)parameter;
            if(!para.IsValidated())
                throw(new InputValidatedError(para.GetErrors()));
            else if(await this.IsExistByName(para.Name))
                throw(new CodeKindIsExistError(para.Name));

            CodeKind createdKind = new CodeKind{
                Name = para.Name,
                NameT = para.NameT
            };
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


        public async Task<CodeKind> UpdateByName(string name, IParameter parameter)
        {
            UpdatedCodeKindParameter para = (UpdatedCodeKindParameter)parameter;
            if(!para.IsValidated())
                throw(new InputValidatedError(para.GetErrors()));

            CodeKind updatedKind = await this.FindByName(name);
            updatedKind.NameT = para.NameT;
            this._unitOfWork.CodeKindRepository.Update(updatedKind);
            await this._unitOfWork.SaveChanges();
            return updatedKind;
        }
    }
}