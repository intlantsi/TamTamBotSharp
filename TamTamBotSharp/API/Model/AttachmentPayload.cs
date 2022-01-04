using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TamTamBot.API.Model
{
    public class AttachmentPayload
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public AttachmentPayload()
        {

        }

        public AttachmentPayload(string url)
        { 
            this.URL = url;
        }
        #endregion

         #region Properties
        [JsonPropertyName("url")]
        public string URL { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is Error)) return false;

            AttachmentPayload attPay = (AttachmentPayload) obj;
            return Object.Equals(this.URL, attPay.URL);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (URL != null ? URL.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "AttachmentPayload{"
                    + " url='" + URL + '\''
                    + '}';
        }
        #endregion
    }
}

