using RChat.BLL.Dto;
using RChat.DAL.Entities;
using RChat.WEB.Models;
using System.Collections.Generic;

namespace RChat.Mappers
{
    public static class RChatMappers
    {
        // USER_MAPPERS
        public static UserDto MapUserEntityToDto(this UserEntity userEntity)
        {
            if (userEntity == null)
                return null;

            return new UserDto()
            {
                UserId = userEntity.UserId, Name = userEntity.Name, Login = userEntity.Login, Password = userEntity.Password,
            };
        }
        public static UserModel MapUserDtoToModel(this UserDto userDto)
        {
            if (userDto == null)
                return null;

            return new UserModel()
            { 
                UserId = userDto.UserId, Name = userDto.Name, Login = userDto.Login, Password = userDto.Password 
            };            
        }      
        public static UserDto MapUserModelToDto(this UserModel userModel)
        {
            if (userModel == null)
                return null;

            return new UserDto()
            { 
                UserId = userModel.UserId, Name = userModel.Name, Login = userModel.Login, Password = userModel.Password
            };
        }
        public static UserEntity MapUserDtoToEntity(this UserDto userDto)
        {
            if (userDto == null)
                return null;

            return new UserEntity()
            {
                UserId = userDto.UserId, Name = userDto.Name, Login = userDto.Login, Password = userDto.Password
            };
        }

        //CHAT_MAPPERS

        public static ChatEntity MapChatDtoToEntity(this ChatDto chatDto)
        {
            if (chatDto == null)
                return null;

            return new ChatEntity()
            {
               ChatId = chatDto.ChatId, Name = chatDto.Name
            };
        }
        public static ChatDto MapChatModelToDto(this ChatModel chatModel)
        {
            if (chatModel == null)
                return null;

            return new ChatDto()
            {
                ChatId = chatModel.ChatId, Name = chatModel.Name, UsersId = chatModel.UsersId
            };
        }

        //MESSAGE_MAPPERS

        public static MessageDto MapMessageModelToDto(this MessageModel messageModel)
        {
            if(messageModel == null)
                return null;

            return new MessageDto()
            {
                MessageId = messageModel.MessageId, Text = messageModel.Text, ChatId = messageModel.ChatId, UserId = messageModel.UserId, Date = messageModel.Date
            };
        }
        public static MessageModel MapMessageDtoToModel(this MessageDto messageDto)
        {
            if (messageDto == null)
                return null;

            return new MessageModel()
            {
                MessageId = messageDto.MessageId,
                Text = messageDto.Text,
                ChatId = messageDto.ChatId,
                UserId = messageDto.UserId,
                Date = messageDto.Date
            };
        }
        public static MessageEntity MapMessageDtoToEntity(this MessageDto messageDto)
        {
            if (messageDto == null)
                return null;

            return new MessageEntity()
            {
                MessageId = messageDto.MessageId, Text = messageDto.Text, Date = messageDto.Date
            };
        }
        public static MessageDto MapMessageEntityToDto(this MessageEntity messageEntity)
        {
            if (messageEntity == null)
                return null;

            return new MessageDto()
            {
                MessageId = messageEntity.MessageId,
                Text = messageEntity.Text,
                Date = messageEntity.Date
            };
        }

        //BOT_MAPPERS

        public static BotEntity MapBotDtoToEntity(this BotDto botDto)
        {
            if (botDto == null)
                return null;

            return new BotEntity()
            {
                BotId = botDto.BotId, Name = botDto.Name
            };

        }
        public static BotDto MapBotModelToDto(this BotModel botModel)
        {
            if (botModel == null)
                return null;

            return new BotDto()
            {
                BotId = botModel.BotId,
                Name = botModel.Name
            };

        }

        //LIST_USER_MAPPERS

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

        //LIST_MESSAGE_MAPPERS

        public static List<MessageDto> MapMessageListEntityToDto(this List<MessageEntity> messageEntities)
        {
            List<MessageDto> messageDtos = new List<MessageDto>();
            foreach (var item in messageEntities)
            {
                messageDtos.Add(item.MapMessageEntityToDto());
            }
            return messageDtos;
        }
        public static List<MessageModel> MapMessageListDtoToModel(this List<MessageDto> messageDtos)
        {
            List<MessageModel> messageModels = new List<MessageModel>();
            foreach (var item in messageDtos)
            {
                messageModels.Add(item.MapMessageDtoToModel());
            }
            return messageModels;
        }
    }
}
