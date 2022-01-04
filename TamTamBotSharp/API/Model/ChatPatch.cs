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
    /// ChatPatch
    /// </summary>
    public class ChatPatch
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public ChatPatch()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Icon
        /// </summary>
        [JsonPropertyName("icon")]
        public PhotoAttachmentRequestPayload Icon { get; init; }
        /// <summary>
        /// Title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; init; }
        /// <summary>
        /// Identifier of message to be pinned in chat. In case you 
        /// want to remove pin, use [unpin](#operation/unpinMessage) method
        /// </summary>
        [JsonPropertyName("pin")]
        public string Pin { get; init; }
        /// <summary>
        /// By default, participants will be notified 
        /// about change with system message in chat/channel
        /// </summary>
        [JsonPropertyName("notify")]
        public bool Notify { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is ChatPatch)) return false;

            ChatPatch cp = (ChatPatch) obj;
            return Object.Equals(this.Icon, cp.Icon) &&
                   Object.Equals(this.Title, cp.Title) &&
                   Object.Equals(this.Pin, cp.Pin) &&
                   Object.Equals(this.Notify, cp.Notify);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Icon != null ? Icon.GetHashCode() : 0);
            result = 31 * result + (Title != null ? Title.GetHashCode() : 0);
            result = 31 * result + (Pin != null ? Pin.GetHashCode() : 0);
            result = 31 * result + (Notify != null ? Notify.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "ChatPatch{"
                    + " icon='" + Icon + '\''
                    + " title='" + Title + '\''
                    + " pin='" + Pin + '\''
                    + " notify='" + Notify + '\''
                    + '}';
        }
        #endregion
    }
}