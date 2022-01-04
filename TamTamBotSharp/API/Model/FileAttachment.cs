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
    /// FileAttachment
    /// </summary>
    public class FileAttachment : Attachment
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public FileAttachment():base()
        {

        }

        public FileAttachment(FileAttachmentPayload payload, string filename, long size) : base()
        {
            this.Payload = payload;
            this.FileName = filename;
            this.Size = size;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Payload
        /// </summary>
        [JsonPropertyName("payload")]
        public FileAttachmentPayload Payload { get; init; }
        /// <summary>
        /// Uploaded file name
        /// </summary>
        [JsonPropertyName("filename")]
        public string FileName { get; init; }
        /// <summary>
        /// File size in bytes
        /// </summary>
        [JsonPropertyName("size")]
        public long Size { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is FileAttachment)) return false;

            FileAttachment fileAtt = (FileAttachment)obj;
            return Object.Equals(this.Payload, fileAtt.Payload) &&
                   Object.Equals(this.FileName, fileAtt.FileName) &&
                   Object.Equals(this.Size, fileAtt.Size);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Payload != null ? Payload.GetHashCode() : 0);
            result = 31 * result + (FileName != null ? FileName.GetHashCode() : 0);
            result = 31 * result + (Size != null ? Size.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "FileAttachment{" + base.ToString()
            + " payload='" + Payload + '\''
            + " filename='" + FileName + '\''
            + " size='" + Size + '\''
            + '}';
        }
        #endregion
    }
}

