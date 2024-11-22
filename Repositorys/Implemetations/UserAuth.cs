using EnergyQuiz.Data;
using EnergyQuiz.DTOs;
using EnergyQuiz.Models;
using EnergyQuiz.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnergyQuiz.Repositorys.Implemetations
{
    public class UserAuth : IUserAuth
    {
        private readonly DataContext _dataContext;
        public UserAuth(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<User> CreateUser(UserRegisterDto request)
        {
           var getUser = await _dataContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (getUser == null)
            {
                User newUser = new User
                {
                    Email = request.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    Name = request.Name
                };
                _dataContext.Users.Add(newUser);
                _dataContext.SaveChanges();

                return newUser;
            }
            return null;
        }

        public void DeleteUSer(int id)
        {
            var user = _dataContext.Users.FirstOrDefault(x=> x.Id == id);
            if (user != null)
            {
                user.isActive = false;
            }
        }

        public async Task<User> GetUserByEmail(UserLoginDto request)
        {
            var getUser = await _dataContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
            if(getUser == null)
            {
                return null;
            }
            if (BCrypt.Net.BCrypt.Verify(request.Password, getUser.Password)) return getUser;

            if (!getUser.isActive)
            {
                return getUser;
            }
            return null;
        }
    }
}
