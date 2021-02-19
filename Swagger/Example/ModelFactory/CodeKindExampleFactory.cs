
using APX.Models;

namespace APX.Swagger.Example
{
    public class CodeKindExampleFactory
    {
        static public CodeKind CreateSystemKind()
        {
            return new CodeKind
            {
                Name = "System    ",
                NameT = "系統代號"
            };
        }


        static public CodeKind UpdateSystemKind()
        {
            return new CodeKind
            {
                Name = "System    ",
                NameT = "系統名稱"
            };
        }
    }
}