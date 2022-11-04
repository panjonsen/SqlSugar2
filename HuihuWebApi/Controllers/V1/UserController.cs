using DTOModel.UserDTO;
using Helper;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace HuihuWebApi.Controllers.V1
{
    [Route("api/V1/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //创建用户
        [HttpPost]
        public ActionResult<string> CreateUser(CreateUserDTO createUserDTO)
        {
            UserSerivce userSerivce = new UserSerivce();
            var user = userSerivce.CreateUser(createUserDTO);
            return HttpResultHelper.OkByD(user);
        }

        [HttpPost]
        public ActionResult<string> Login(LoginDTO loginDto)
        {
            return HttpResultHelper.Ok();
        }
    }
}