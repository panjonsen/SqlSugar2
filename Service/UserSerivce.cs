using DTOModel.UserDTO;
using Model.User;
using Service.BaseService;

namespace Service
{
    public class UserSerivce : Base
    {
        public User CreateUser(CreateUserDTO createUserDTO)
        {
            User user = new User();

            user.Username = createUserDTO.Username;
            user.Password = createUserDTO.Password;
            user = db.Insertable(user).ExecuteReturnEntity();

            return user;
        }

        public User? Login(LoginDTO loginDto)
        {
            var user = db.Queryable<User>()
                 .Where(m => m.Username == loginDto.Username)
                 .Where(m => m.Password == loginDto.Password)
                 .First();

            if (user == null)
            {
                return null;
            }



            return null;
        }
    }
}