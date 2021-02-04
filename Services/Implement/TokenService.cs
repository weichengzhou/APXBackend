
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
    public class TokenService : ITokenService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public TokenService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }


        public async Task<Token> Create(CreateTokenDto tokenDto)
        {
            CreateTokenDtoValidator validator = new CreateTokenDtoValidator(tokenDto);
            if(!validator.IsValidated())
                throw(new InputValidatedError(validator.GetErrors()));

            Token createdToken = this._mapper.Map<Token>(tokenDto);
            
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