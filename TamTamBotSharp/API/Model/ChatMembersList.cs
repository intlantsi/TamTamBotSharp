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
    /// ChatMembersList
    /// </summary>
    public class ChatMembersList
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public ChatMembersList()
        {

        }

        public ChatMembersList(List<ChatMember> members)
        {
            this.Members = members;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Participants in chat with time of last activity. Visible only for chat admins
        /// </summary>
        [JsonPropertyName("members")]
        public List<ChatMember> Members { get; init; }
        /// <summary>
        /// Pointer to the next data page
        /// </summary>
        [JsonPropertyName("marker")]
        public long Marker { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is ChatMembersList)) return false;

            ChatMembersList cml = (ChatMembersList)obj;
            return Object.Equals(this.Members, cml.Members) &&
                   Object.Equals(this.Marker, cml.Marker);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Members != null ? Members.GetHashCode() : 0);
            result = 31 * result + (Marker != null ? Marker.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "ChatMembersList{"
                    + " members='" + Members + '\''
                    + " marker='" + Marker + '\''
                    + '}';
        }
        #endregion
    }
}