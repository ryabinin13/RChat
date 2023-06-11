using RChat.DAL.Entities;
using RChat.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.DAL.Repositories
{
    public class UserRepositoryTest //: IUserRepository
    {
        private List<UserEntity> Users = new List<UserEntity>();
       
        //public List<UserEntity> Users { get; set; }


        public void Create(UserEntity item)
        {
            foreach (var user in Users)
            {
                if (user.Id == item.Id)
                {
                    throw new Exception("id не может совпадать");
                }
            }
            Users.Add(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserEntity Get(int id)
        {
            foreach (var item in Users)
            {
                if (id == item.Id)
                {
                    return item;
                }
            }
            return null;
        }

        public List<UserEntity> GetAll()
        {
            return Users;
        }

        public void Update(UserEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
