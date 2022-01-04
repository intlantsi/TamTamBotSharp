using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TamTamBot.API.Model
{
    public class StickerAttachmentPayload:AttachmentPayload
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public StickerAttachmentPayload():base()
        {

        }

        public StickerAttachmentPayload(string code, string url):base(url)
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
            if (obj == null || !(obj is StickerAttachmentPayload)) return false;

            StickerAttachmentPayload sap = (StickerAttachmentPayload) obj;
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
            return "StickerAttachmentPayload{" + base.ToString()
                    + " code='" + Code + '\''
                    + '}';
        }
        #endregion
    }
}