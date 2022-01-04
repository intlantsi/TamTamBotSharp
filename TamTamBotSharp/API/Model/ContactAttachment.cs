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
    /// ContactAttachment
    /// </summary>
    public class ContactAttachment : Attachment
    {
        #region Fields
        
        #endregion

        #region Constructor
        [JsonConstructor]
        public ContactAttachment():base()
        {

        }

        public ContactAttachment(ContactAttachmentPayload payload) : base()
        {
            this.Payload = payload;
        }
        #endregion

        #region Properties
        [JsonPropertyName("payload")]
        public ContactAttachmentPayload Payload { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is ContactAttachment)) return false;

            ContactAttachment ca = (ContactAttachment)obj;
            return Object.Equals(this.Payload, ca.Payload);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Payload != null ? Payload.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "ContactAttachment{" + base.ToString()
                    + " payload='" + Payload + '\''
                    + '}';
        }
        #endregion
    }
}
