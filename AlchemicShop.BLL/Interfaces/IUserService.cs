using System;
using System.Collections.Generic;
using AlchemicShop.BLL.DTO;

namespace AlchemicShop.BLL.Interfaces
{
    public interface IUserService
    {
        void AddUser(UserDTO userDto);
        UserDTO GetUser(int? id);
        IEnumerable<UserDTO> GetUsers();
        void Dispose();
    }
}