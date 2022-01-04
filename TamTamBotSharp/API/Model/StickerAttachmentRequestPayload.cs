using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TamTamBot.API.Model
{
    public class StickerAttachmentRequestPayload
    {
        #region Fields
        
        #endregion

        #region Constructor
        public StickerAttachmentRequestPayload(string code)
        {
            this.Code = code;
        }
        #endregion

        #region Properties
        [JsonPropertyName("code")]
        public string Code { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is StickerAttachmentRequestPayload)) return false;

            StickerAttachmentRequestPayload sap = (StickerAttachmentRequestPayload)obj;
            return Object.Equals(this.Code, sap.Code) && base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Code != null ? Code.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "StickerAttachmentRequestPayload{" + base.ToString()
                    + " code='" + Code + '\''
                    + '}';
        }
        #endregion
    }
}
