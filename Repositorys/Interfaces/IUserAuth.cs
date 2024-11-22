using EnergyQuiz.DTOs;
using EnergyQuiz.Models;

namespace EnergyQuiz.Repositorys.Interfaces
{
    public interface IUserAuth
    {
        Task<User> GetUserByEmail(UserLoginDto request);
        Task<User> CreateUser(UserRegisterDto request);
        void DeleteUSer(int id);
    }
}
