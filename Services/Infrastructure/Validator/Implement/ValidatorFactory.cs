
using APX.Models.Dto;

namespace APX.Services.Validator
{
    public class ValidatorFactory
    {
        #region Event Validator
        static public IValidator CreateEventDtoValidator(CreateEventDto dto)
        {
            return new CreateEventDtoValidator(dto);
        }


        static public IValidator UpdateEventDtoValidator(UpdateEventDto dto)
        {
            return new UpdateEventDtoValidator(dto);
        }
        #endregion

        #region Token Validator
        static public IValidator CreateTokenDtoValidator(CreateTokenDto dto)
        {
            return new CreateTokenDtoValidator(dto);
        }
        #endregion

        #region CodeKind Validator
        static public IValidator CreateCodeKindDtoValidator(CreateCodeKindDto dto)
        {
            return new CreateCodeKindDtoValidator(dto);
        }


        static public IValidator UpdateCodeKindDtoValidator(UpdateCodeKindDto dto)
        {
            return new UpdateCodeKindDtoValidator(dto);
        }
        #endregion

        #region Code Validator
        static public IValidator CreateCodeDtoValidator(CreateCodeDto dto)
        {
            return new CreateCodeDtoValidator(dto);
        }


        static public IValidator UpdateCodeDtoValidator(UpdateCodeDto dto)
        {
            return new UpdateCodeDtoValidator(dto);
        }
        #endregion
    }
}