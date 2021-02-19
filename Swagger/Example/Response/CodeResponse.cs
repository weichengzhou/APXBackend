
using System.Collections.Generic;

using APX.Models;

namespace APX.Swagger.Example
{
    public class CreateCodeResponseExample : SucceedResponseExample<Code>
    {
        public override Code Result
        {
            get => CodeExampleFactory.CreateAPXCode();
        }


        public override string Message
        {
            get => "Code is created.";
        }
    }


    public class GetCodesResponseExample : SucceedResponseExample<List<Code>>
    {
        public override List<Code> Result
        {
            get
            {
                return new List<Code>
                {
                    CodeExampleFactory.CreateAPXCode(),
                    CodeExampleFactory.CreateAPSCode()
                };
            }
        }


        public override string Message
        {
            get => "Find 2 records.";
        }
    }


    public class GetCodeResponseExample : SucceedResponseExample<Code>
    {
        public override Code Result
        {
            get => CodeExampleFactory.CreateAPSCode();
        }


        public override string Message
        {
            get => "Find Code ID APS.";
        }
    }


    public class UpdateCodeResponseExample : SucceedResponseExample<Code>
    {
        public override Code Result
        {
            get => CodeExampleFactory.UpdateAPXCode();
        }


        public override string Message
        {
            get => "Update Code ID APS.";
        }
    }
}