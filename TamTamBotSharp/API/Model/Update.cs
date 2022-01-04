using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using TamTamBotSharp.API.Extensions;

namespace TamTamBot.API.Model
{
    /// <summary>
    /// Update object represents different types of events that happened in chat. See its inheritors
    /// </summary>
    [JsonConverter(typeof(UpdateConverter))]
    public class Update
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public Update()
        {

        }

        public Update(long timestamp)
        { 
            this.TimeStamp = timestamp;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Unix-time when event has occurred
        /// </summary>
        [JsonPropertyName("timestamp")]
        public long TimeStamp { get; init; }
        [JsonPropertyName("update_type")]
        public UpdateTypes UpdateType { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is Update)) return false;

            Update upd = (Update) obj;
            return Object.Equals(this.TimeStamp, upd.TimeStamp);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (TimeStamp != null ? TimeStamp.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "Update{"
                    + " timestamp='" + TimeStamp + '\''
                    + '}';
        }
        #endregion
    }

    /// <summary>
    /// Generic schema representing message attachment JSON converter
    /// </summary>
    public class UpdateConverter : JsonConverter<Update>
    {
        public override Update Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            UpdateTypes type = Enum.Parse<UpdateTypes>(reader.GetTokenValue("type"), true);
            var result = type switch
            {
                UpdateTypes.MessageCreated => JsonSerializer.Deserialize<MessageCreatedUpdate>(ref reader, options),
                UpdateTypes.MessageCallback => JsonSerializer.Deserialize<MessageCallbackUpdate>(ref reader, options),
                UpdateTypes.MessageEdited => JsonSerializer.Deserialize<MessageEditedUpdate>(ref reader, options),
                UpdateTypes.MessageRemoved => JsonSerializer.Deserialize<MessageRemovedUpdate>(ref reader, options),
                UpdateTypes.BotAdded => JsonSerializer.Deserialize<BotAddedToChatUpdate>(ref reader, options),
                UpdateTypes.BotRemoved => JsonSerializer.Deserialize<BotRemovedFromChatUpdate>(ref reader, options),
                UpdateTypes.UserAdded => JsonSerializer.Deserialize<UserAddedToChatUpdate>(ref reader, options),
                UpdateTypes.UserRemoved => JsonSerializer.Deserialize<UserRemovedFromChatUpdate>(ref reader, options),
                UpdateTypes.BotStarted => JsonSerializer.Deserialize<BotStartedUpdate>(ref reader, options),
                UpdateTypes.ChatTitleChanged => JsonSerializer.Deserialize<ChatTitleChangedUpdate>(ref reader, options),
                UpdateTypes.MessageConstructionRequest => JsonSerializer.Deserialize<MessageConstructedUpdate>(ref reader, options),
                UpdateTypes.MessageChatCreated => JsonSerializer.Deserialize<MessageChatCreatedUpdate>(ref reader, options),
                _ => new Update(0)
            };
            return result;
        }


        public override void Write(Utf8JsonWriter writer, Update upd, JsonSerializerOptions options)
        {
            switch (upd.UpdateType)
            {
                case UpdateTypes.MessageCreated:
                    JsonSerializer.Serialize<MessageCreatedUpdate>(writer, (MessageCreatedUpdate) upd, options);
                    break;
                case UpdateTypes.MessageCallback:
                    JsonSerializer.Serialize<MessageCallbackUpdate>(writer, (MessageCallbackUpdate)upd, options);
                    break;
                case UpdateTypes.MessageEdited:
                    JsonSerializer.Serialize<MessageEditedUpdate>(writer, (MessageEditedUpdate) upd, options);
                    break;
                case UpdateTypes.MessageRemoved:
                    JsonSerializer.Serialize<MessageRemovedUpdate>(writer, (MessageRemovedUpdate) upd, options);
                    break;
                case UpdateTypes.BotAdded:
                    JsonSerializer.Serialize<BotAddedToChatUpdate>(writer, (BotAddedToChatUpdate) upd, options);
                    break;
                case UpdateTypes.BotRemoved:
                    JsonSerializer.Serialize<BotRemovedFromChatUpdate>(writer, (BotRemovedFromChatUpdate) upd, options);
                    break;
                case UpdateTypes.UserAdded:
                    JsonSerializer.Serialize<UserAddedToChatUpdate>(writer, (UserAddedToChatUpdate) upd, options);
                    break;
                case UpdateTypes.UserRemoved:
                    JsonSerializer.Serialize<UserRemovedFromChatUpdate>(writer, (UserRemovedFromChatUpdate) upd, options);
                    break;
                case UpdateTypes.BotStarted:
                    JsonSerializer.Serialize<BotStartedUpdate>(writer, (BotStartedUpdate) upd, options);
                    break;
                case UpdateTypes.ChatTitleChanged:
                    JsonSerializer.Serialize<ChatTitleChangedUpdate>(writer, (ChatTitleChangedUpdate) upd, options);
                    break;
                case UpdateTypes.MessageConstructionRequest:
                    JsonSerializer.Serialize<MessageConstructedUpdate>(writer, (MessageConstructedUpdate) upd, options);
                    break;
                case UpdateTypes.MessageChatCreated:
                    JsonSerializer.Serialize<MessageChatCreatedUpdate>(writer, (MessageChatCreatedUpdate) upd, options);
                    break;
                default:
                    break;
            }
        }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UpdateTypes
    {
        [EnumMember(Value = "message_created")]
        MessageCreated,
        [EnumMember(Value = "message_callback")]
        MessageCallback,
        [EnumMember(Value = "message_edited")]
        MessageEdited,
        [EnumMember(Value = "message_removed")]
        MessageRemoved,
        [EnumMember(Value = "bot_added")]
        BotAdded,
        [EnumMember(Value = "bot_removed")]
        BotRemoved,
        [EnumMember(Value = "user_added")]
        UserAdded,
        [EnumMember(Value = "user_removed")]
        UserRemoved,
        [EnumMember(Value = "bot_started")]
        BotStarted,
        [EnumMember(Value = "chat_title_changed")]
        ChatTitleChanged,
        [EnumMember(Value = "message_construction_request")]
        MessageConstructionRequest,
        [EnumMember(Value = "message_chat_created")]
        MessageChatCreated
    }
}