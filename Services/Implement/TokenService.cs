
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using APX.Services.UnitOfWork;
using APX.Services.Parameter;
using APX.Services.Exceptions;
using APX.Models;

namespace APX.Services
{
    public class TokenService : ITokenService
    {
        private IUnitOfWork _unitOfWork;

        public TokenService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        public async Task<Token> Create(IParameter parameter)
        {
            CreatedTokenParameter para = (CreatedTokenParameter)parameter;
            if(!para.IsValidated())
                throw(new InputValidatedError(para.GetErrors()));

            Token createdToken = new Token{
                Body = para.Body,
                CreatedUser = para.CreatedUser,
                CreatedDate = DateTime.Now,
                UpdatedUser = para.CreatedUser,
                UpdatedDate = DateTime.Now
            };
            await this._unitOfWork.TokenRepository.Create(createdToken);
            await this._unitOfWork.SaveChanges();
            return createdToken;
        }


        public async Task<bool> IsExistBySeq(string seq)
        {
            return await this._unitOfWork.TokenRepository.IsExistBySeq(seq);
        }


        public async Task<IEnumerable<Token>> FindAll()
        {
            return await this._unitOfWork.TokenRepository.FindAll();
        }


        public async Task<Token> FindBySeq(string seq)
        {
            if(!await this.IsExistBySeq(seq))
                throw(new TokenNotFoundError(seq));
            return await this._unitOfWork.TokenRepository.FindBySeq(seq);
        }
    }
}