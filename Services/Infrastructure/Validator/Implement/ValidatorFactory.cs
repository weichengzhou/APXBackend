
using APX.Models.Dto;

namespace APX.Services.Validator
{
    public class ValidatorFactory
    {
        # region CreateDtoValidator
        static public IValidator CreateDtoValidator(CodeDto dto)
        {
            return new CodeDtoValidator(dto);
        }


        static public IValidator CreateDtoValidator(CodeKindDto dto)
        {
            return new CodeKindDtoValidator(dto);
        }


        static public IValidator CreateDtoValidator(EventDto dto)
        {
            return new CreateEventDtoValidator(dto);
        }


        static public IValidator CreateDtoValidator(TokenDto dto)
        {
            return new CreateTokenDtoValidator(dto);
        }
        #endregion


        #region UpdateDtoValidator
        static public IValidator UpdateDtoValidator(CodeDto dto)
        {
            return new CodeDtoValidator(dto);
        }


        static public IValidator UpdateDtoValidator(CodeKindDto dto)
        {
            return new CodeKindDtoValidator(dto);
        }


        static public IValidator UpdateDtoValidator(EventDto dto)
        {
            return new UpdateEventDtoValidator(dto);
        }


        static public IValidator UpdateDtoValidator(TokenDto dto)
        {
            return new UpdateTokenDtoValidator(dto);
        }
        #endregion
    }
}