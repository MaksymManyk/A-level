using Services.Abstractions; 
using DTOs; 
using DTOs.Requests;
namespace RESTProject
{
    public class App
    {
        private readonly IUserService _userService;
        private readonly IResourceService _resourceService;
        private readonly IRegisterService _registerService;

        public App(IUserService userService, IResourceService resourceService, IRegisterService registerService )
        {
            _userService = userService;
            _resourceService = resourceService;
            _registerService = registerService;
        }

        public async Task Start()
        {
            int page = 2;
            int userID = 2;
            int userIDWrong = 22;
            int resourceID = 4;
            int resourceIDWrong = 30;
            UserCreateDTO userCreateDTO = new UserCreateDTO { Name ="morpheus", Job = "leader"};
            UserCreateDTO userUpdateDTO = new UserCreateDTO { Name = "morpheus", Job = "zion resident", ID = 2 };
            UserCreateDTO userDeleteDTO = new UserCreateDTO { ID = 2 };
            RegisterRequest register = new RegisterRequest { Email = "eve.holt@reqres.in", Password = "pistol" };
            RegisterRequest userRegisterFalse = new RegisterRequest { Email = "sydney@fife"};
            RegisterRequest userLogin = new RegisterRequest { Email = "eve.holt@reqres.in", Password = "cityslicka" };
            RegisterRequest userLoginFalse = new RegisterRequest { Email = "peter@klaven" };

            var userList = await _userService.GetListUsersByPage(page);
            Console.WriteLine($"Users from page #:{page}:{Environment.NewLine}");
            foreach (var user in userList.Data.Data)
            {
                _userService.PrintUser(user);
            }

            var userByID = await _userService.GetUserById(userID);
            _userService.PrintUserByID(userByID, userID);

            var userByIDWrong = await _userService.GetUserById(userIDWrong);
            _userService.PrintUserByID(userByIDWrong, userIDWrong);

            var resourceList = await _resourceService.GetListResourse();
            Console.WriteLine($"Resource from page #:{Environment.NewLine}");
            foreach (var resource in resourceList.Data.Data)
            {
                _resourceService.PrintResource(resource);
            }

            var resourceByID = await _resourceService.GetResourceById(resourceID);
            _resourceService.PrintSingleResource(resourceByID, resourceID);

            var resourceByIDWrong = await _resourceService.GetResourceById(resourceIDWrong);
            _resourceService.PrintSingleResource(resourceByIDWrong, resourceIDWrong);

            var userCreate = await _userService.CreateUser(userCreateDTO);
            _userService.PrintCreateUser(userCreate, userCreateDTO);

            var userUpdatePut = await _userService.UpdateUser(userUpdateDTO,HttpMethod.Put );
            _userService.PrintUpdateUser(userUpdatePut, userUpdateDTO, HttpMethod.Put);

            var userUpdatePatch = await _userService.UpdateUser(userUpdateDTO, HttpMethod.Patch);
            _userService.PrintUpdateUser(userUpdatePatch, userUpdateDTO, HttpMethod.Patch);

            var userDelete = await _userService.DeleteUser(userDeleteDTO);
            _userService.PrintDeleteUser(userDelete, userDeleteDTO);

            var registerTrue = await _registerService.CreateLogin(register);
            _registerService.PrintCreateLogin(registerTrue, register);

            var registerFalse = await _registerService.CreateLogin(userRegisterFalse);
            _registerService.PrintCreateLogin(registerFalse, userRegisterFalse);

            var login = await _registerService.Login(userLogin);

            _registerService.PrintLogin(login, userLogin);

            var loginFalse = await _registerService.Login(userLoginFalse);

            _registerService.PrintLogin(loginFalse, userLoginFalse);
        }
    }
}