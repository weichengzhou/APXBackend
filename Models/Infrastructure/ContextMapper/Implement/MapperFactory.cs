
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APX.Models.Context.Mapper
{
    /* Uses Factory to create Mapper.
    |  Depends on type of inputs, given different Mapper.
    */
    public class MapperFactory
    {
        static public IContextMapper CreateMapper(EntityTypeBuilder<Code> builder)
        {
            return new CodeMapper(builder);
        }


        static public IContextMapper CreateMapper(EntityTypeBuilder<CodeKind> builder)
        {
            return new CodeKindMapper(builder);
        }


        static public IContextMapper CreateMapper(EntityTypeBuilder<Event> builder)
        {
            return new EventMapper(builder);
        }


        static public IContextMapper CreateMapper(EntityTypeBuilder<Token> builder)
        {
            return new TokenMapper(builder);
        }
    }
}