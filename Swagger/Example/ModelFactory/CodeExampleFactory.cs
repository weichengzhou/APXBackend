
using APX.Models;

namespace APX.Swagger.Example
{
    public class CodeExampleFactory
    {
        static public Code CreateAPXCode()
        {
            return new Code
            {
                ID = "APX",
                Kind = "System",
                SortOrder = "1",
                NameT = "資料交換",
                Content = "紀錄API存取Log"
            };
        }


        static public Code UpdateAPXCode()
        {
            return new Code
            {
                ID = "APX",
                Kind = "System",
                SortOrder = "2",
                NameT = "紀錄資料",
                Content = ""
            };
        }



        static public Code CreateAPSCode()
        {
            return new Code
            {
                ID = "APS",
                Kind = "System",
                SortOrder = "2",
                NameT = "工作排程",
                Content = "工作排程與通知系統"
            };
        }
    }
}