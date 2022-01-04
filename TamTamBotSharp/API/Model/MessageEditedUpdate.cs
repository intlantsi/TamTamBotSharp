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
    /// You will get this update as soon as message is edited
    /// </summary>
    public class MessageEditedUpdate : Update
    {
        #region Fields
        //private readonly Message message;
        #endregion

        #region Constructor
        [JsonConstructor]
        public MessageEditedUpdate():base()
        {

        }

        public MessageEditedUpdate(Message message, long timestamp) : base(timestamp)
        {
            this.EditedMsg = message;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Edited message
        /// </summary>
        [JsonPropertyName("message")]
        public Message EditedMsg { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is MessageEditedUpdate)) return false;

            MessageEditedUpdate msgEdUpd = (MessageEditedUpdate)obj;
            return Object.Equals(this.EditedMsg, msgEdUpd.EditedMsg) &&
                   base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (EditedMsg != null ? EditedMsg.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "MessageEditedUpdate{" + base.ToString()
                    + " message='" + EditedMsg + '\''
                    + '}';
        }
        #endregion
    }
}
