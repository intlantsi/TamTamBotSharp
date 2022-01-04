using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Drawing;

namespace TamTamBot.API.Model
{
    /// <summary>
    /// Chat
    /// </summary>
    public class Chat
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructorAttribute]
        public Chat()
        {

        }

        public Chat(long chatId, ChatTypes type, ChatStatusTypes status, string title, Image icon,
            long lastEventTime, int participantsCount, bool isPublic, object description)
        {
            this.ChatId = chatId;
            this.ChatType = type;
            this.ChatStatusType = status;
            this.Title = title;
            this.Icon = icon;
            this.LastEventTime = lastEventTime;
            this.ParticipantsCount = participantsCount;
            this.IsPublic = isPublic;
            this.Description = description;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Chats identifier
        /// </summary>
        [JsonPropertyName("chat_id")]
        public long ChatId { get; init; }
        /// <summary>
        /// Type of chat. One of: dialog, chat, channel
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ChatTypes ChatType { get; init; }
        /// <summary>
        /// Chat status. One of:  
        /// - active: bot is active member of chat  
        /// - removed: bot was kicked  
        /// - left: bot intentionally left chat  
        /// - closed: chat was closed
        /// </summary>
        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ChatStatusTypes ChatStatusType { get; init; }
        /// <summary>
        /// Visible title of chat. Can be null for dialogs
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; init; }
        /// <summary>
        /// Icon of chat
        /// </summary>
        [JsonPropertyName("icon")]
        public Image Icon { get; init; }
        /// <summary>
        /// Time of last event occurred in chat
        /// </summary>
        [JsonPropertyName("last_event_time")]
        public long LastEventTime { get; init; }
        /// <summary>
        /// Number of people in chat. Always 2 for "dialog" chat type
        /// </summary>
        [JsonPropertyName("participants_count")]
        public int ParticipantsCount { get; init; }
        /// <summary>
        /// Identifier of chat owner. Visible only for chat admins
        /// </summary>
        [JsonPropertyName("owner_id")]
        public long OwnerId { get; init; }
        /// <summary>
        /// Participants in chat with time of last activity. Can be *null* 
        /// when you request list of chats. Visible for chat admins only
        /// </summary>
        [JsonPropertyName("participants")]
        public Dictionary<string, long> Participants { get; init; } = new Dictionary<string, long>();
        /// <summary>
        /// Is current chat publicly available. Always false for dialogs
        /// </summary>
        [JsonPropertyName("is_public")]
        public bool IsPublic { get; init; }
        /// <summary>
        /// Link on chat if it is public
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; init; }
        /// <summary>
        /// Chat description
        /// </summary>
        [JsonPropertyName("description")]
        public object Description { get; init; }
        /// <summary>
        /// Another user in conversation. For dialog type chats only
        /// </summary>
        [JsonPropertyName("dialog_with_user")]
        public UserWithPhoto DialogWithUser { get; init; }
        /// <summary>
        /// Messages count in chat. Only for group chats and channels. 
        /// **Not available** for dialogs
        /// </summary>
        [JsonPropertyName("messages_count")]
        public int MessagesCount { get; init; }
        /// <summary>
        /// Identifier of message that contains "chat" button initialized chat
        /// </summary>
        [JsonPropertyName("chat_message_id")]
        public string ChatMessageId { get; init; }
        /// <summary>
        /// Pinned message in chat or channel. Returned only when single chat is requested
        /// </summary>
        [JsonPropertyName("pinned_message")]
        public Message PinnedMessage { get; init; }
        #endregion

        #region Methods
        public Chat AddParticipantsItem(string key, long participantsItem)
        {
            this.Participants.Add(key, participantsItem);
            return this;
        }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is Chat)) return false;

            Chat chat = (Chat)obj;
            return Object.Equals(this.ChatId, chat.ChatId) &&
                   Object.Equals(this.ChatType, chat.ChatType) &&
                   Object.Equals(this.ChatStatusType, chat.ChatStatusType) &&
                   Object.Equals(this.Title, chat.Title) &&
                   Object.Equals(this.Icon, chat.Icon) &&
                   Object.Equals(this.LastEventTime, chat.LastEventTime) &&
                   Object.Equals(this.ParticipantsCount, chat.ParticipantsCount) &&
                   Object.Equals(this.OwnerId, chat.OwnerId) &&
                   Object.Equals(this.Participants, chat.Participants) &&
                   Object.Equals(this.IsPublic, chat.IsPublic) &&
                   Object.Equals(this.Link, chat.Link) &&
                   Object.Equals(this.Description, chat.Description) &&
                   Object.Equals(this.DialogWithUser, chat.DialogWithUser) &&
                   Object.Equals(this.MessagesCount, chat.MessagesCount) &&
                   Object.Equals(this.ChatMessageId, chat.ChatMessageId) &&
                   Object.Equals(this.PinnedMessage, chat.PinnedMessage);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (ChatId != null ? ChatId.GetHashCode() : 0);
            result = 31 * result + (ChatType != null ? ChatType.GetHashCode() : 0);
            result = 31 * result + (ChatStatusType != null ? ChatStatusType.GetHashCode() : 0);
            result = 31 * result + (Title != null ? Title.GetHashCode() : 0);
            result = 31 * result + (Icon != null ? Icon.GetHashCode() : 0);
            result = 31 * result + (LastEventTime != null ? LastEventTime.GetHashCode() : 0);
            result = 31 * result + (ParticipantsCount != null ? ParticipantsCount.GetHashCode() : 0);
            result = 31 * result + (OwnerId != null ? OwnerId.GetHashCode() : 0);
            result = 31 * result + (Participants != null ? Participants.GetHashCode() : 0);
            result = 31 * result + (IsPublic != null ? IsPublic.GetHashCode() : 0);
            result = 31 * result + (Link != null ? Link.GetHashCode() : 0);
            result = 31 * result + (Description != null ? Description.GetHashCode() : 0);
            result = 31 * result + (DialogWithUser != null ? DialogWithUser.GetHashCode() : 0);
            result = 31 * result + (MessagesCount != null ? MessagesCount.GetHashCode() : 0);
            result = 31 * result + (ChatMessageId != null ? ChatMessageId.GetHashCode() : 0);
            result = 31 * result + (PinnedMessage != null ? PinnedMessage.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "Chat{"
            + " chatId='" + ChatId + '\''
            + " type='" + ChatType + '\''
            + " status='" + ChatStatusType + '\''
            + " title='" + Title + '\''
            + " icon='" + Icon + '\''
            + " lastEventTime='" + LastEventTime + '\''
            + " participantsCount='" + ParticipantsCount + '\''
            + " ownerId='" + OwnerId + '\''
            + " participants='" + Participants + '\''
            + " isPublic='" + IsPublic + '\''
            + " link='" + Link + '\''
            + " description='" + Description + '\''
            + " dialogWithUser='" + DialogWithUser + '\''
            + " messagesCount='" + MessagesCount + '\''
            + " chatMessageId='" + ChatMessageId + '\''
            + " pinnedMessage='" + PinnedMessage + '\''
            + '}';
        }
        #endregion
    }
}



