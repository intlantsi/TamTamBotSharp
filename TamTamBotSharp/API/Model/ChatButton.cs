using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TamTamBot.API.Model
{
    /// <summary>
    /// Button that creates new chat as soon as the first user clicked on it. 
    /// Bot will be added to chat participants as administrator. Message author will be owner of the chat.
    /// </summary>
    public class ChatButton : Button
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public ChatButton():base()
        {

        }

        public ChatButton(string chatTitle, string text) : base(text)
        {
            this.ChatTitle = chatTitle;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Title of chat to be created
        /// </summary>
        [JsonPropertyName("chat_title")]
        public string ChatTitle { get; init; }
        /// <summary>
        /// Chat description
        /// </summary>
        [JsonPropertyName("chat_description")]
        public string ChatDescription { get; init; }
        /// <summary>
        /// Start payload will be sent to bot as soon as chat created
        /// </summary>
        [JsonPropertyName("start_payload")]
        public string StartPayload { get; init; }
        /// <summary>
        /// Unique button identifier across all chat buttons in keyboard. 
        /// If uuid changed, new chat will be created on the next click. 
        /// Server will generate it at the time when button initially posted. 
        /// Reuse it when you edit the message.
        /// </summary>
        [JsonPropertyName("uuid")]
        public int UUID { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is ChatButton)) return false;

            ChatButton chatBtn = (ChatButton)obj;
            return Object.Equals(this.ChatTitle, chatBtn.ChatTitle) &&
                   Object.Equals(this.ChatDescription, chatBtn.ChatDescription) &&
                   Object.Equals(this.StartPayload, chatBtn.StartPayload) &&
                   Object.Equals(this.UUID, chatBtn.UUID) &&
                   base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int result = base.GetHashCode();
            result = 31 * result + (ChatTitle != null ? ChatTitle.GetHashCode() : 0);
            result = 31 * result + (ChatDescription != null ? ChatDescription.GetHashCode() : 0);
            result = 31 * result + (StartPayload != null ? StartPayload.GetHashCode() : 0);
            result = 31 * result + (UUID != null ? UUID.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "ChatButton{" + base.ToString()
                    + " chatTitle='" + ChatTitle + '\''
                    + " chatDescription='" + ChatDescription + '\''
                    + " startPayload='" + StartPayload + '\''
                    + " uuid='" + UUID + '\''
                    + '}';
        }
        #endregion
    }
}