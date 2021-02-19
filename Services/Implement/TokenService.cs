
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


        public async Task<Token> Create(TokenDto tokenDto)
        {
            IValidator validator = ValidatorFactory.CreateDtoValidator(tokenDto);
            if(!validator.IsValidated())
                throw(new InputValidatedError(validator.GetErrors()));

            Token createdToken = this._mapper.Map<Token>(tokenDto);
            createdToken.UpdatedUser = createdToken.CreatedUser;
            createdToken.CreatedDate = DateTime.Now;
            
            await this._unitOfWork.TokenRepository.Create(createdToken);
            await this._unitOfWork.SaveChanges();
            return createdToken;
        }


        public async Task<bool> IsExistBySEQ(string seq)
        {
            return await this._unitOfWork.TokenRepository.IsExistBySEQ(seq);
        }


        public async Task<IEnumerable<Token>> FindAll()
        {
            return await this._unitOfWork.TokenRepository.FindAll();
        }


        public async Task<Token> FindBySEQ(string seq)
        {
            if(!await this.IsExistBySEQ(seq))
                throw(new TokenNotFoundError(seq));
            return await this._unitOfWork.TokenRepository.FindBySEQ(seq);
        }
    }
}