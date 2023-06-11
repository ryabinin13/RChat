using RChat.BLL.Dto;
using RChat.DAL.Entities;
using RChat.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RChat.Mappers
{
    public static class RChatMappers
    {
        public static UserDto MapUserEntityToDto(this UserEntity userEntity)
        {
            if (userEntity == null)
                return null;

            return new UserDto(userEntity.Id, userEntity.Name, userEntity.Login, userEntity.Password);
        }
        public static UserModel MapUserDtoToModel(this UserDto userDto)
        {
            if (userDto == null)
                return null;

            return new UserModel(userDto.Id, userDto.Name, userDto.Login, userDto.Password);            
        }
        public static UserEntity MapUserDtoToEntity(this UserDto userDto)
        {
            if (userDto == null)
                return null;

            return new UserEntity(userDto.Id, userDto.Name,  userDto.Login, userDto.Password);         
        }
        public static UserDto MapUserModelToDto(this UserModel userModel)
        {
            if (userModel == null)
                return null;

            return new UserDto(userModel.Id, userModel.Name, userModel.Login, userModel.Password);
        }
        public static List<UserDto> MapUserListEntityToDto(this List<UserEntity> userEntities)
        {
            List<UserDto> userDtos = new List<UserDto>();
            foreach (var item in userEntities)
            {
                userDtos.Add(item.MapUserEntityToDto());
            }
            return userDtos;
        }
        public static List<UserModel> MapUserListDtoToModel(this List<UserDto> userDtos)
        {
            List<UserModel> userModels = new List<UserModel>();
            foreach (var item in userDtos)
            {
                userModels.Add(item.MapUserDtoToModel());
            }
            return userModels;
        }
    }
}
