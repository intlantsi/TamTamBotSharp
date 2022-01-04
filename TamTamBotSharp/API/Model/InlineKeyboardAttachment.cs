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
    /// Buttons in messages
    /// </summary>
    public class InlineKeyboardAttachment:Attachment
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public InlineKeyboardAttachment()
        {

        }

        public InlineKeyboardAttachment(Keyboard payload) : base()
        {
            this.Payload = payload;
        }
        #endregion

        #region Properties
        [JsonPropertyName("payload")]
        public Keyboard Payload { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is InlineKeyboardAttachment)) return false;

            InlineKeyboardAttachment ika = (InlineKeyboardAttachment) obj;
            return Object.Equals(this.Payload, ika.Payload);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Payload != null ? Payload.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "InlineKeyboardAttachment{" + base.ToString()
                    + " payload='" + Payload + '\''
                    + '}';
        }
        #endregion
    }
}