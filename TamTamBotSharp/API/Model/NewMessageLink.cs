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
    /// NewMessageLink
    /// </summary>
    public class NewMessageLink
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public NewMessageLink()
        {

        }

        public NewMessageLink(MessageLinkTypes type, string mid)
        {
            this.NewMessageLinkType = type;
            this.Mid = mid;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Type of message link
        /// </summary>
        [JsonPropertyName("type")]
        public MessageLinkTypes NewMessageLinkType { get; init; }
        /// <summary>
        /// Message identifier of original message
        /// </summary>
        [JsonPropertyName("mid")]
        public string Mid { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is NewMessageLink)) return false;

            NewMessageLink nml = (NewMessageLink) obj;
            return Object.Equals(this.NewMessageLinkType, nml.NewMessageLinkType) &&
                   Object.Equals(this.Mid, nml.Mid);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (NewMessageLinkType != null ? NewMessageLinkType.GetHashCode() : 0);
            result = 31 * result + (Mid != null ? Mid.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "NewMessageLink{"
                    + " type='" + NewMessageLinkType + '\''
                    + " mid='" + Mid + '\''
                    + '}';
        }
        #endregion
    }
}