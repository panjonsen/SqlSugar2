using Service.BaseService;
using Model;

namespace Service
{
    public class UserSerivce : Base
    {
        public void CreateUser(string userName, string passWord)
        {
            User user = new User();

            user.Username = userName;
            user.Password = passWord;

            user = db.Insertable(user).ExecuteReturnEntity();

            Console.WriteLine(user.ToString());
        }
    }
}