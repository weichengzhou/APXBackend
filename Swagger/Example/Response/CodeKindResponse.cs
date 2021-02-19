
using System.Collections.Generic;

using APX.Models;

namespace APX.Swagger.Example
{
    public class CreateCodeKindResponseExample : SucceedResponseExample<CodeKind>
    {
        public override CodeKind Result
        {
            get => CodeKindExampleFactory.CreateSystemKind();
        }


        public override string Message
        {
            get => "CodeKind is created.";
        }
    }


    public class GetCodeKindsResponseExample : SucceedResponseExample<List<CodeKind>>
    {
        public override List<CodeKind> Result
        {
            get
            {
                return new List<CodeKind>
                {
                    CodeKindExampleFactory.CreateSystemKind()
                };
            }
        }


        public override string Message
        {
            get => "Find 1 records.";
        }
    }


    public class GetCodeKindResponseExample : SucceedResponseExample<CodeKind>
    {
        public override CodeKind Result
        {
            get => CodeKindExampleFactory.CreateSystemKind();
        }


        public override string Message
        {
            get => "Find CodeKind Name System.";
        }
    }


    public class UpdateCodeKindResponseExample : SucceedResponseExample<CodeKind>
    {
        public override CodeKind Result
        {
            get => CodeKindExampleFactory.UpdateSystemKind();
        }


        public override string Message
        {
            get => "Update CodeKind Name System.";
        }
    }
}