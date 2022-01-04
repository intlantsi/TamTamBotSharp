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
    /// ContactAttachmentPayload
    /// </summary>
    public class ContactAttachmentPayload
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public ContactAttachmentPayload()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// User info in VCF format
        /// </summary>
        [JsonPropertyName("vcf_info")]
        public string VCFInfo { get; init; }
        /// <summary>
        /// User info
        /// </summary>
        [JsonPropertyName("tam_info")]
        public User TamInfo { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is ContactAttachmentPayload)) return false;

            ContactAttachmentPayload cap = (ContactAttachmentPayload) obj;
            return Object.Equals(this.VCFInfo, cap.VCFInfo) &&
                   Object.Equals(this.TamInfo, cap.TamInfo);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (VCFInfo != null ? VCFInfo.GetHashCode() : 0);
            result = 31 * result + (TamInfo != null ? TamInfo.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "ContactAttachmentPayload{"
                    + " vcfInfo='" + VCFInfo + '\''
                    + " tamInfo='" + TamInfo + '\''
                    + '}';
        }
        #endregion
    }
}
