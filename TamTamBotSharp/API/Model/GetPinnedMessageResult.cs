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
    /// GetPinnedMessageResult
    /// </summary>
    public class GetPinnedMessageResult
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public GetPinnedMessageResult()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Pinned message. Can be null if no message pinned in chat
        /// </summary>
        [JsonPropertyName("message")]
        public Message PinnedMessage { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is GetPinnedMessageResult)) return false;

            GetPinnedMessageResult pmr = (GetPinnedMessageResult) obj;
            return Object.Equals(this.PinnedMessage, pmr.PinnedMessage);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (PinnedMessage != null ? PinnedMessage.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "GetPinnedMessageResult{"
                    + " message='" + PinnedMessage + '\''
                    + '}';
        }
        #endregion
    }
}