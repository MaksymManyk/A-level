using DTOs.Requests;
using DTOs.Responses;

namespace Services.Abstractions
{
    public interface IRegisterService
    {
        Task<MainResponce<RegisterResponce>> CreateLogin(RegisterRequest login);

        Task<MainResponce<RegisterResponce>> Login(RegisterRequest login);

        public void PrintLogin(MainResponce<RegisterResponce> responce, RegisterRequest user);

        public void PrintCreateLogin(MainResponce<RegisterResponce> responce, RegisterRequest user);
    }
}
