
using System.Threading.Tasks;
using System.Collections.Generic;

using APX.Models;
using APX.Services.UnitOfWork;
using APX.Services.Parameter;
using APX.Services.Exceptions;

namespace APX.Services
{
    public class CodeService : ICodeService
    {
        private IUnitOfWork _unitOfWork;

        public CodeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        public async Task<Code> Create(IParameter parameter)
        {
            CreatedCodeParameter para = (CreatedCodeParameter)parameter;
            if(!para.IsValidated())
                throw(new InputValidatedError(para.GetErrors()));
            else if(await this.IsExistById(para.Id))
                throw(new CodeIsExistError(para.Id));
            else if(!await this._unitOfWork.CodeKindRepository
                .IsExistByName(para.Kind))
                throw(new CodeKindNotFoundError(para.Kind));

            Code createdCode = new Code{
                Id = para.Id,
                Kind = para.Kind,
                SortOrder = para.SortOrder,
                NameT = para.NameT,
                Content = para.Content
            };
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


        public async Task<Code> UpdateById(string id, IParameter parameter)
        {
            UpdatedCodeParameter para = (UpdatedCodeParameter)parameter;
            if(!para.IsValidated())
                throw(new InputValidatedError(para.GetErrors()));
            if(para.Kind != null &
                !await this._unitOfWork.CodeKindRepository.IsExistByName(para.Kind))
                throw(new CodeKindNotFoundError(para.Kind));

            Code updatedCode = await this.FindById(id);
            updatedCode.Kind = para.Kind ?? updatedCode.Kind;
            updatedCode.SortOrder = para.SortOrder ?? updatedCode.SortOrder;
            updatedCode.NameT = para.NameT ?? updatedCode.NameT;
            updatedCode.Content = para.Content ?? updatedCode.Content;
            this._unitOfWork.CodeRepository.Update(updatedCode);
            await this._unitOfWork.SaveChanges();
            return updatedCode;
        }
    }
}