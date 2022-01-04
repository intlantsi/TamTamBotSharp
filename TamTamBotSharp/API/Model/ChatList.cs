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
    /// ChatList
    /// </summary>
    public class ChatList
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public ChatList()
        {

        }

        public ChatList(List<Chat> chats, long marker)
        {
            this.Chats = chats;
            this.Marker = marker;
        }
        #endregion

        #region Properties
        /// <summary>
        /// List of requested chats
        /// </summary>
        [JsonPropertyName("chats")]
        public List<Chat> Chats { get; init; }
        /// <summary>
        /// Reference to the next page of requested chats
        /// </summary>
        [JsonPropertyName("marker")]
        public long Marker { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is ChatList)) return false;

            ChatList chatLst = (ChatList)obj;
            return Object.Equals(this.Chats, chatLst.Chats) &&
                   Object.Equals(this.Marker, chatLst.Marker);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Chats != null ? Chats.GetHashCode() : 0);
            result = 31 * result + (Marker.GetHashCode());
            return result;
        }

        public override string ToString()
        {
            return "ChatList{"
                    + " chats='" + Chats + '\''
                    + " marker='" + Marker + '\''
                    + '}';
        }
        #endregion
    }
}
