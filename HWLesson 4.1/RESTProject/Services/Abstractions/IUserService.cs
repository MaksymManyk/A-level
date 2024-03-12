using DTOs.Responses;
using DTOs;

namespace Services.Abstractions
{
    public interface IUserService
    {
        Task<MainResponce<ListResponse<List<UserDTO>>>> GetListUsersByPage(int page);

        Task<MainResponce<BaseResponse<UserDTO>>> GetUserById(int id);

        Task<MainResponce<UserCreateResponse>> CreateUser(UserCreateDTO user);

        Task<MainResponce<UserUpdateResponse>> UpdateUser(UserCreateDTO user, HttpMethod method);

        Task<MainResponce<BaseResponse<UserDTO>>> DeleteUser(UserCreateDTO user);

        public void PrintDeleteUser(MainResponce<BaseResponse<UserDTO>> responce, UserCreateDTO user);

        public void PrintUpdateUser(MainResponce<UserUpdateResponse> responce, UserCreateDTO user, HttpMethod method);

        public void PrintCreateUser(MainResponce<UserCreateResponse> responce, UserCreateDTO user);

        public void PrintUser(UserDTO user);

        public void PrintUserByID(MainResponce<BaseResponse<UserDTO>> responce, int id);
    }
}
