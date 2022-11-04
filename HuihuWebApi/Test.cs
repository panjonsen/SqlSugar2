using Helper;
using Model.User;

namespace HuihuWebApi
{
    public class InitClass : SqlSugarHelper
    {
        public static void Init()
        {
            db.CodeFirst.InitTables(typeof(User));
        }
    }
}