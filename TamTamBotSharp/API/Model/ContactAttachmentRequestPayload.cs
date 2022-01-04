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
    /// ContactAttachmentRequestPayload
    /// </summary>
    public class ContactAttachmentRequestPayload
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public ContactAttachmentRequestPayload()
        {

        }

        public ContactAttachmentRequestPayload(string name)
        {
            this.Name = name;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Contact name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; init; }
        /// <summary>
        /// Contact identifier if it is reigstered TamTam user
        /// </summary>
        [JsonPropertyName("contact_id")]
        public long ContactId { get; init; }
        /// <summary>
        /// Full information about contact in VCF format
        /// </summary>
        [JsonPropertyName("vcf_info")]
        public string VCFInfo { get; init; }
        /// <summary>
        /// Contact phone in VCF format
        /// </summary>
        [JsonPropertyName("vcf_phone")]
        public string VCFPhone { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is ContactAttachmentRequestPayload)) return false;

            ContactAttachmentRequestPayload carp = (ContactAttachmentRequestPayload)obj;
            return Object.Equals(this.Name, carp.Name) &&
                   Object.Equals(this.ContactId, carp.ContactId) &&
                   Object.Equals(this.VCFInfo, carp.VCFInfo) &&
                   Object.Equals(this.VCFPhone, carp.VCFPhone);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Name != null ? Name.GetHashCode() : 0);
            result = 31 * result + (ContactId != null ? ContactId.GetHashCode() : 0);
            result = 31 * result + (VCFInfo != null ? VCFInfo.GetHashCode() : 0);
            result = 31 * result + (VCFPhone != null ? VCFPhone.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "ContactAttachmentRequestPayload{"
                    + " name='" + Name + '\''
                    + " contactId='" + ContactId + '\''
                    + " vcfInfo='" + VCFInfo + '\''
                    + " vcfPhone='" + VCFPhone + '\''
                    + '}';
        }
        #endregion
    }
}
